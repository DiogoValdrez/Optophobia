using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGmae()
    {
        GameManager.instance.ClearSaves();
        GameManager.instance.player.SetPlayerAlive();
        GameManager.instance.player.hitpoint = 3;
        GameManager.instance.SaveState();
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
       
}
