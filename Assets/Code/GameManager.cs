using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//static makes it a global variable(to access: GameManager.instance) 
    
    //References 
    public Player player;
    public GameObject playerWrapper;
    public GameObject DeathMenuCanvas;
    public float orbitSpeed = 1f;
    public float volume = 0.5f;


    private void Awake()
    {
        //this prevents creating new game manager
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            //Destroy(floatingTextManager.gameObject);

            return;
        }

        //This cleans up all saves
        //ClearSaves();

        // Make sure this is the only "instance"
        instance = this;
        //this event get triggred after a scene is loaded and calls the functions in the plus
        SceneManager.sceneLoaded += LoadState;

        //this make sure that the game manager maintains alive even if we change scene
        DontDestroyOnLoad(gameObject);
        //to prevent duplicates of the game manager when returning to main we could just put the game manager on the loading screen before the game starts
    }

    
    public void Start(){
        AudioListener.volume = volume;
    }

    public void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
    }

    
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += volume.ToString() + "|";
        s += orbitSpeed.ToString() + "|";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        //prevents from calling multiple times
        //SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        volume = float.Parse(data[1]);
        orbitSpeed = float.Parse(data[2]);

        playerWrapper.transform.position = GameObject.Find("SpawnPoint").transform.position;
        DeathMenuCanvas = GameObject.Find("CanvasDeathMenu");

    }

    public void SetOrbitSpeed(float percentage)
    {
        orbitSpeed = percentage;
        SaveState();
    }

    public void SetVolume(float percentage)
    {
        volume = percentage;
        SaveState();
    }

}