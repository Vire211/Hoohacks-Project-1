using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScript : MonoBehaviour
{
    public int x;
    public int y;

    public GameObject debris;

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

        float rotAmount = 480f * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = other.gameObject.layer;

        if (layer == 7)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().incermentScore();
            shootDebris();
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
