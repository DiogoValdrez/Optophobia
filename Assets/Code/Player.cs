using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{   
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
}