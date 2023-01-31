using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class OpenDoor : Collidable
{
    public List<GameObject> enemies;
    protected SpriteRenderer DoorOpenSprite;
    protected BoxCollider2D PortalCollider;
    protected Light2D light2D;
    public string sceneName;

    protected AudioSource audioSource;

    protected GameObject test;

    protected override void Start()
    {
        base.Start();
        DoorOpenSprite = GetComponent<SpriteRenderer>();
        PortalCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        light2D = GetComponentInChildren<Light2D>();
        audioSource.Play();
        audioSource.Pause();
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
            audioSource.UnPause();
            DoorOpenSprite.enabled = true;
            PortalCollider.enabled = true;
            light2D.enabled = true;
        }
    }

    protected override void OnColide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            //Teleport the player
            GameManager.instance.SaveState();
            //string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            //GameManager.instance.playerWrapper.SetActive(true);
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
