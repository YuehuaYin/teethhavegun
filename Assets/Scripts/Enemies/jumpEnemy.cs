using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpEnemy : MonoBehaviour
{
    Vector2 moveD;
    Rigidbody2D rb;
    public int speed;
    public int health;
    public bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        health = 30;
        rb.velocity = newDir(Mathf.RoundToInt(Random.Range(0, 8)));
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding == true) {
            rb.velocity = newDir(Mathf.RoundToInt(Random.Range(0, 8)));
        }
    }

    void OnCollisionEnter2D()
    {
        colliding = true;
    }

    void OnCollisionExit2D()
    {
        colliding = false;
    }

    Vector2 newDir(int dir)
    {
        if (dir == 0) {
            return (new Vector2(speed * -1f, speed * 1f));
        }
        else if (dir == 1)
        {
            return (new Vector2(speed * -0.5f, speed * 1.75f));
        }
        else if (dir == 2)
        {
            return (new Vector2(speed * 0.5f, speed * 1.75f));
        }
        else if (dir == 3)
        {
            return (new Vector2(speed * 1f, speed * 1f));
        }
        else if (dir == 4)
        {
            return (new Vector2(speed * 1f, speed * -1f));
        }
        else if (dir == 5)
        {
            return (new Vector2(speed * 0.5f, speed * -1.75f));
        }
        else if (dir == 6)
        {
            return (new Vector2(speed * -0.5f, speed * -1.75f));
        }
        else
        {
            return (new Vector2(speed * -1f, speed * -1f));
        }
    }
}
