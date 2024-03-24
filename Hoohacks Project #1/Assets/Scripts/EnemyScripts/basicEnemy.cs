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

    public GameObject debris;

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
                shootDebris();
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (layer == 6)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().incermentScore();
                shootDebris();
                Destroy(this.gameObject);
            }
        }
    }

    private void shootDebris()
    {
        int type = Random.Range(0, 2);

        if (type == 0)
        {
            GameObject newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(1, -1, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, -1, 0) * 5;
        }
        else
        {
            GameObject newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0) * 5;

            newDebris = (GameObject)Instantiate(debris, transform.position, Quaternion.identity);
            newDebris.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1, 0) * 5;
        }
    }
}
