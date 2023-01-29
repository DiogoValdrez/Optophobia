using UnityEngine;
//using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    //public string[] sceneNames;
    public string sceneName;
    protected override void OnColide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            //Teleport the player
            //GameManager.instance.SaveState();
            //string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}