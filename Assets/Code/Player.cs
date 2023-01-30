using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{   
    public GameObject deathMenuCanvas;
    public bool playerDead = false;

    protected AudioSource audioSource;//TODO: maybe meter no mover

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.Pause();
        DontDestroyOnLoad(transform.parent.gameObject);// this also saves its children
    }

    void FixedUpdate()
    {
        //get the input(maybe trade with button insted of horizontal and vertical)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0 || y != 0)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }

        UpdateParentMotor(new Vector3(x,y,0)); 

    }

    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
        if(ahh)
        {
            transform.parent.GetComponentInChildren<OrbitMaker>().RemoveLastObjectInOrbit();
            ahh = false; 
        }         
    }

    public override void Death()
    {
        Time.timeScale = 0f;
        deathMenuCanvas.transform.GetChild(0).gameObject.SetActive(true);
        playerDead = true;
        //Destroy(transform.parent.gameObject);
    }

    public bool IsPlayerDead()
    {
        return playerDead;
    }
    public bool SetPlayerAlive()
    {
        return playerDead = false;
    }
}