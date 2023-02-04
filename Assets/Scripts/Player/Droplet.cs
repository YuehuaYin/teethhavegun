using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public int skin;
    public int speed;
    Rigidbody2D rb;
    public int direction = 1;
    public bool facingR;
    // Start is called before the first frame update
    void Start()
    {
        skin = GameStatistics.item2Level;
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().enabled = true;
        if (facingR)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bEnmy = collision.collider.GetComponent<basicEnemy>();
        var jEnmy = collision.collider.GetComponent<jumpEnemy>();
        var tEnmy = collision.collider.GetComponent<tankEnemy>();
        if (bEnmy != null)
        {
            bEnmy.health -= GameStatistics.rangeDamage;
        }
        if (jEnmy != null)
        {
            jEnmy.health -= GameStatistics.rangeDamage;
        }
        if (tEnmy != null)
        {
            tEnmy.health -= GameStatistics.rangeDamage;
        }
        Destroy(gameObject);
    }
}
