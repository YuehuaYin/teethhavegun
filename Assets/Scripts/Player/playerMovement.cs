using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Vector2 moveD;
    Rigidbody2D rb;
    public float speed;
    public int jumpSpeed;

    [Header("Ground Check Stuff")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundCheckHeight;
    [SerializeField] float disableTime;
    private bool jumping;
    private Vector2 bCenter;
    private Vector2 bSize;
    private WaitForSeconds wait;
    private CapsuleCollider2D capsuleCollider;

    private Animator animator;

    bool atkRdy = true;
    bool facingR = true;

    [SerializeField] GameObject ToothbrushR;
    [SerializeField] GameObject ToothBrushL;
    [SerializeField] GameObject Gun1;
    [SerializeField] GameObject Gun2;
    [SerializeField] GameObject DropPrefab;
    GameObject currentBrush;
    GameObject currentGun;

    bool vulnerable = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        wait = new WaitForSeconds(disableTime);
        animator = GetComponent<Animator>();
        ToothbrushR.GetComponent<SpriteRenderer>().enabled = false;
        ToothbrushR.GetComponent<BoxCollider2D>().enabled = false;
        ToothBrushL.GetComponent<SpriteRenderer>().enabled = false;
        ToothBrushL.GetComponent<BoxCollider2D>().enabled = false;
        Gun1.GetComponent<SpriteRenderer>().enabled = false;
        Gun2.GetComponent<SpriteRenderer>().enabled = false;
        currentBrush = ToothbrushR;
        currentGun = Gun1;
        GameObject.Find("Canvas").GetComponent<GameUI>().startLife();

        speed = GameStatistics.speed;
    }

    private void FixedUpdate()
    {
        if (moveD.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (atkRdy)
            {
                currentBrush = ToothBrushL;
                currentGun = Gun2;
                facingR = false;
            }
            animator.SetBool("moving", true);
        }
        else if (moveD.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (atkRdy)
            {
                currentBrush = ToothbrushR;
                currentGun = Gun1;
                facingR = true;
            }
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
        rb.velocity = new Vector2(speed * moveD.x, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveD = new Vector2(context.ReadValue<Vector2>().x, 0);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            StartCoroutine(EnableCheckAfterJump());
        }
    }

    private bool IsGrounded()
    {
        //box that checks if player is touching the ground
        bCenter = new Vector2(capsuleCollider.bounds.center.x, capsuleCollider.bounds.center.y) +
                        (Vector2.down * (capsuleCollider.bounds.extents.y + (groundCheckHeight / 2f)));
        bSize = new Vector2(capsuleCollider.bounds.size.x, groundCheckHeight);
        var groundBox = Physics2D.OverlapBox(bCenter, bSize, 0f, groundMask);

        if (groundBox != null)
        {
            return true;

        }
        return false;
    }
    private IEnumerator EnableCheckAfterJump()
    {
        yield return wait;
    }

    //Check for collisions with enemies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Touched an enemy");
            if (vulnerable)
            {
                StartCoroutine(Invincibility());
                GameObject.Find("Canvas").GetComponent<GameUI>().loseLife();

                if (GameObject.Find("Canvas").GetComponent<GameUI>().lives == 0)
                {
                    death();
                }
            }
        }
    }
    IEnumerator Invincibility()
    {
        vulnerable = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        vulnerable = true;
    }
    public void OnMelee(InputAction.CallbackContext context)
    {
        if (atkRdy)
        {
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Attack()
    {
        atkRdy = false;
        currentBrush.GetComponent<SpriteRenderer>().enabled = true;
        currentBrush.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        currentBrush.GetComponent<SpriteRenderer>().enabled = false;
        currentBrush.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        atkRdy = true;
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (atkRdy)
        {
            StartCoroutine(ShowGun());
            GameObject droplet = Instantiate(DropPrefab, gameObject.transform);
            droplet.GetComponent<Droplet>().facingR = facingR;
            droplet.SetActive(true);
        }
    }
    private IEnumerator ShowGun()
    {
        currentGun.GetComponent<SpriteRenderer>().enabled = true;
        atkRdy = false;
        yield return new WaitForSeconds(0.3f);
        currentGun.GetComponent<SpriteRenderer>().enabled = false;
        atkRdy = true;
    }

    public void death()
    {
        GameStatistics.MONEY += GameObject.Find("Canvas").GetComponent<GameUI>().score / 100;
        GameStatistics.maxScore = Mathf.Max(GameStatistics.maxScore, GameObject.Find("Canvas").GetComponent<GameUI>().score);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        SceneManager.LoadScene("shop");
    }
}
