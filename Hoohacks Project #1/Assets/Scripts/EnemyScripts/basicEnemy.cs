using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    public int x;
    public int y;

    private Rigidbody2D rb;

    public float speed;
    public bool normal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       rb.velocity  = new Vector3(x, y, 0) * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = other.gameObject.layer;

        if (normal)
        {
            if (layer == 7)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().incermentScore();
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (layer == 6)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().incermentScore();
                Destroy(this.gameObject);
            }
        }
    }
}
