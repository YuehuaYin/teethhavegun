using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEnemy : MonoBehaviour
{
    Vector2 moveD;
    Rigidbody2D rb;
    public int speed;
    public int direction;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 300;
    }

    // Update is called once per frame
    void Update()
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
    }
}
