using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game Button Pressed");
        Application.Quit();
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        Debug.Log("Jagger VW");
    }

    public void HowToPlay()
    {
        Debug.Log("We will add this later :)");
    }
}
