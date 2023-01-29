using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{   
    public GameObject deathMenuCanvas;

    protected override void Start()
    {
        base.Start();      
    }
    void FixedUpdate()
    {
        //get the input(maybe trade with button insted of horizontal and vertical)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateParentMotor(new Vector3(x,y,0));        
    }

    //TODO: ADD receive damage and death and destroying heartswhen  receiving
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
        deathMenuCanvas.SetActive(true);
        //Destroy(transform.parent.gameObject);
    }
}