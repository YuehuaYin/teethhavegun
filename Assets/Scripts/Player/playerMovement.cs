using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Vector2 moveD;
    Rigidbody2D rb;
    public int speed;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        wait = new WaitForSeconds(disableTime);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (moveD.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("moving", true);
        }
        else if (moveD.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
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
        }
    }
}
