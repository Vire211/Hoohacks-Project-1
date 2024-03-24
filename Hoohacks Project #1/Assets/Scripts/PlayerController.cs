using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject shield;
    public GameObject sword;

    public GameObject gameOverPanel;
    public GameObject instructionsPanel;

    private int health;
    private bool dead;

    private int score;
    public bool start;

    private bool blocking;
    private bool attacking;
    private bool cooldown;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        blocking = false;
        cooldown = false;
        health = 3;
        dead = false;

        start = false;

        score = 0;

        gameOverPanel.SetActive(false);
        instructionsPanel.SetActive(true);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            scoreText.text = "Score: " + score;
            healthText.text = "Health: " + health;

            if (!dead)
            {
                if (!blocking && !attacking)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }

                if (Input.GetMouseButtonDown(1) && !blocking && !cooldown && !attacking)
                {
                    StartCoroutine(block());
                }

                if (Input.GetMouseButtonDown(0) && !blocking && !cooldown && !attacking)
                {
                    StartCoroutine(attack());
                }
            }
            else
            {
                gameOverPanel.SetActive(true);
            }
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

    IEnumerator countdown()
    {
        countText.text = "3";
        instructionsPanel.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        countText.text = "2";

        yield return new WaitForSeconds(1.0f);

        countText.text = "1";

        yield return new WaitForSeconds(1.0f);

        countText.text = "";
        start = true;
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

    public void startGame()
    {
        StartCoroutine(countdown());
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
