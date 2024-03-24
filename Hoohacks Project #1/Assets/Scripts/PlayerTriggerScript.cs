using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerScript : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = other.gameObject.layer;

        if (layer == 8)
        {
            player.decrementHealth();
            if (player.getHealth() <= 0)
            {
                player.setDead(true);
            }

            Destroy(other.gameObject);
        }
        else if (layer == 9)
        {
            player.decrementHealth();
            if (player.getHealth() <= 0)
            {
                player.setDead(true);
            }

            Destroy(other.gameObject);
        }
    }
}
