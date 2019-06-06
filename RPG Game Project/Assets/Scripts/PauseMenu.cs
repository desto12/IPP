using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Reasume();
         
            }
            else
            {
                Pause();
            }
        }
    }
    void Reasume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");

    }

    // Update is called once per frame
    public void QuitBUtton()
    {
        Application.Quit();

    }
    public void ReasumeBUtton()
    {
        Reasume();

    }
}
