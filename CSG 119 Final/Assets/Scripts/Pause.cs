using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
