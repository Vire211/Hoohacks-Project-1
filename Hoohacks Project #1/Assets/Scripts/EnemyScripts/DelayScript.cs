using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    public int x;
    public int y;

    private Rigidbody2D rb;

    public float speed;
    private bool waiting;
    private bool waited;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waiting = false;
        waited = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            rb.velocity = new Vector3(x, y, 0) * speed;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 3 && !waited)
        {
            StartCoroutine(wait());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = other.gameObject.layer;

        if (layer == 7)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().incermentScore();
            Destroy(this.gameObject);
        }
    }

    IEnumerator wait()
    {
        waiting = true;

        yield return new WaitForSeconds(1.0f);

        waited = true;
        waiting = false;
    }
}
