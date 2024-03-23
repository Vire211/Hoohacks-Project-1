using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rb;
    public GameObject shield;
    public GameObject sword;

    private bool blocking;
    private bool attacking;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        blocking = false;
        cooldown = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blocking && !attacking)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 0;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 2;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 3;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }

        if (Input.GetMouseButtonDown(0) && !blocking && !cooldown && !attacking)
        {
            StartCoroutine(block());
        }

        if (Input.GetMouseButtonDown(1) && !blocking && !cooldown && !attacking)
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator block()
    {
        blocking = true;
        shield.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        shield.SetActive(false);
        blocking = false;

        StartCoroutine(cool());
    }

    IEnumerator attack()
    {
        attacking = true;
        sword.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        sword.SetActive(false);
        attacking = false;

        StartCoroutine(cool());
    }

    IEnumerator cool()
    {
        cooldown = true;

        yield return new WaitForSeconds(0.5f);

        cooldown = false;
    }
}
