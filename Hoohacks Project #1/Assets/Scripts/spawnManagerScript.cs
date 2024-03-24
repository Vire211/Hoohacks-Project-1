using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManagerScript : MonoBehaviour
{
    private float spawnInterval;
    private bool canSpawn;

    private PlayerController player;
    private int score;
    private int size;

    public GameObject[] enemies;
    public GameObject[] enemies1;
    public GameObject[] enemies2;
    public GameObject[] enemies3;

    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = 3.0f;
        canSpawn = true;
        size = 1;

        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.getDead() && player.start)
        {
            calculateInterval();

            if (player.getScore() < 10)
            {
                size = 1;
            }
            else if (player.getScore() >= 10 && player.getScore() < 20)
            {
                size = 2;
            }
            else
            {
                size = 3;
            }

            if (canSpawn)
            {
                StartCoroutine(spawn());
            }
        }
    }

    IEnumerator spawn()
    {
        canSpawn = false;
        int spawn = Random.Range(0, spawners.Length);

        switch (spawn)
        {
            case 0:
                Instantiate(enemies[Random.Range(0, size)], spawners[spawn].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemies1[Random.Range(0, size)], spawners[spawn].transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemies3[Random.Range(0, size)], spawners[spawn].transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemies2[Random.Range(0, size)], spawners[spawn].transform.position, Quaternion.identity);
                break;
        }

        yield return new WaitForSeconds(spawnInterval);

        canSpawn = true;
    }

    private void calculateInterval()
    {
        if (player.getScore() != 0)
        {
            spawnInterval = Mathf.Log(player.getScore(), 10) + 3;
        }
        else
        {
            spawnInterval = 3.0f;
        }

        if (spawnInterval < 0.6)
        {
            spawnInterval = 0.6f;
        }
    }
}
