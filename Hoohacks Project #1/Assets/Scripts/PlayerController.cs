using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rb;
    public GameObject shield;
    public GameObject sword;

    public GameObject gameOverPanel;

    private int health;
    private bool dead;

    private int score;

    private bool blocking;
    private bool attacking;
    private bool cooldown;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        blocking = false;
        cooldown = false;
        health = 3;
        dead = false;

        score = 0;

        gameOverPanel.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        if (!dead)
        {
            if (!blocking && !attacking)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
                {
                    direction = 0;
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
                {
                    direction = 2;
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
                {
                    direction = 1;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
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
        else
        {
            gameOverPanel.SetActive(true);
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

        yield return new WaitForSeconds(0.1f);

        cooldown = false;
    }

    public void incermentScore()
    {
        score += 1;
    }

    public void decrementHealth()
    {
        health -= 1;
    }

    public void setDead(bool d)
    {
        dead = true;
    }

    public bool getDead()
    {
        return dead;
    }

    public int getHealth()
    {
        return health;
    }

    public int getScore()
    {
        return score;
    }

    public void retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
