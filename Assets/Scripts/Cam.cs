using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x < -3)
        {
            transform.position = new Vector3(-3, 1, transform.position.z);
        }
        else if (Player.transform.position.x > 46) 
        {
            transform.position = new Vector3(46, 1, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, 1, transform.position.z);
        }
        
    }
}
