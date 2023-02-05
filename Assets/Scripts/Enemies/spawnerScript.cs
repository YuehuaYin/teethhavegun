using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject bEnemy;
    public GameObject tEnemy;
    public GameObject jEnemy;
    public float delay;
    private float timer = 0;
    private int random;

    // Start is called before the first frame update
    void Start()
    {
        random = Mathf.RoundToInt(Random.Range(0, 3));
        random = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawn();
            timer = 0;
            setDelay();
        }
    }

    public void spawn()
    {
        if (random == 0)
        {
            Instantiate(bEnemy, transform.position, transform.rotation);
        }
        else if (random == 1)
        {
            Instantiate(tEnemy, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(jEnemy, transform.position, transform.rotation);
        }
        random = Mathf.RoundToInt(Random.Range(0, 3));
    }

    public void setDelay()
    {
        Debug.Log((float)(GameObject.Find("Canvas").GetComponent<GameUI>().score)/10000);
        delay = Mathf.Max(1, 3 - (float)(GameObject.Find("Canvas").GetComponent<GameUI>().score) / 10000);
    }
}
