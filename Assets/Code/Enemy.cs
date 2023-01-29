using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public Transform playerTransform;
    private Vector3 startingPosition;
    public float triggerLenght = 3;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collidingWithPlayer;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();    
        hitbox = transform.parent.GetChild(1).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()//TODO: ADD the rest from TOPDUNGEON and change to follow until you leave the room maybe
    {
        // Is the player in range?
        // if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        // {
        //     if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
        //     {
        //         chasing = true;
        //     }

        //     if(chasing)
        //     {
        //         if (!collidingWithPlayer)
        //         {
        //             UpdateParentMotor((playerTransform.position - transform.position).normalized);
        //         }
        //     }
        //     else
        //     {
        //         UpdateParentMotor(startingPosition - transform.position);
        //     }

        // }
        // else
        // {
        //     UpdateParentMotor(startingPosition - transform.position);
        //     chasing = false;
        // }
        if (!collidingWithPlayer)
        {
            UpdateParentMotor((playerTransform.position - transform.position).normalized);
        }


        // Check for overlaps
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if(hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            // clean up array
            hits[i] = null;
        }
        UpdateParentMotor(new Vector3(0,0,0));
    }
    public override void Death()
    {
        Destroy(transform.parent.gameObject);
    }
}