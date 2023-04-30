using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void quitGame()
    {
        print("quitting");
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("titleScreen");
    }
}
