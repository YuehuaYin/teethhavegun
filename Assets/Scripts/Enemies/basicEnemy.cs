using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    Vector2 moveD;
    Rigidbody2D rb;
    public int speed;
    public int direction;
    public int health;
    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 100;
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("destroyed");
            GameObject.Find("Canvas").GetComponent<GameUI>().addScore(GameStatistics.bEnemy);
            Destroy(gameObject);
        }
        if (!hit)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        }
    }
    public IEnumerator stun()
    {
        hit = true;
        yield return new WaitForSeconds(0.2f);
        hit = false;
        resetSpeed();
    }
    public void resetSpeed()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "RightSideTrigger")
        {
            direction = -1;
        }
        else if (col.gameObject.name == "LeftSideTrigger")
        {
            direction = 1;
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Toothbrush"))
        {
            Debug.Log("melee attack on enemy");
            
            var vector = (transform.position - col.transform.position).normalized;
            var force = vector * 20;
            rb.AddForce(force, ForceMode2D.Impulse);
            StartCoroutine(stun());
            health -= GameStatistics.damage;
        }
        resetSpeed();
    }
}
