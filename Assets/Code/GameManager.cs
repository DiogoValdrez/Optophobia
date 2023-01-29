using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//static makes it a global variable(to access: GameManager.instance) 
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
        //PlayerPrefs.DeleteAll();

        // Make sure this is the only "instance"
        instance = this;
        //this event get triggred after a scene is loaded and calls the functions in the plus
        //SceneManager.sceneLoaded += LoadState;

        //this make sure that the game manager maintains alive even if we change scene
        DontDestroyOnLoad(gameObject);
        //to prevent duplicates of the game manager when returning to main we could just put the game manager on the loading screen before the game starts
    }

     //References 
    public Player player;
    //public Weapon weapon;
    //public FloatingTextManager floatingTextManager;
    //public RectTransform hitPointBar;//there is 2 ways to dont destry on load, just say dontdestroyonload in awayke, or this way


}