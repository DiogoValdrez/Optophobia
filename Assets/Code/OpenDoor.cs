using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Collidable
{
    public List<GameObject> enemies;
    protected SpriteRenderer DoorOpenSprite;
    protected BoxCollider2D PortalCollider;
    public string sceneName;

    protected GameObject test;

    protected override void Start()
    {
        base.Start();
        DoorOpenSprite = GetComponent<SpriteRenderer>();
        PortalCollider = GetComponent<BoxCollider2D>();
    }

    protected override void Update()
    {
        base.Update();

        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
        
        if(enemies.Count == 0)
        {
            DoorOpenSprite.enabled = true;
            PortalCollider.enabled = true;
        }
    }

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