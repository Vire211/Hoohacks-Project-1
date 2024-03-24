using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exit()
    {
        Application.Quit();
    }
}
