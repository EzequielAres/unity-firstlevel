using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
