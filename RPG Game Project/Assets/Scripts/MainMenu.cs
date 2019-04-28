using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("WorldMap");

    }

    // Update is called once per frame
    public void QuitBUtton()
    {
        Application.Quit();

    }
}
