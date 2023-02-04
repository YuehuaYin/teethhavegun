using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public int knockbackStr;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit");

        var rb = col.GetComponent<Rigidbody2D>();

        var vector = (col.gameObject.transform.position - transform.position).normalized;
        var force = vector * knockbackStr;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
