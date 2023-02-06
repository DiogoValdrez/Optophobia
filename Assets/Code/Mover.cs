using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter //Abstracted means that can only be inherited and cant be drag and droped somwhere
{
    protected BoxCollider2D collider2d;
    public float speed = 4;
    protected RaycastHit2D hit;
    protected Vector3 moveDelta;

    protected virtual void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
    protected virtual void UpdateParentMotor(Vector3 input){
        float x = input.x * speed * Time.deltaTime;
        float y = input.y * speed * Time.deltaTime;
        moveDelta = new Vector3(x, y, 0);

        // Fix diagonal speed boost bug
        if (x != 0 && y != 0){
            x = x*Mathf.Sqrt(2)/2;
            y = y*Mathf.Sqrt(2)/2;
        }

        //rotate the sprite, 
        if(x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }else if(x > 0){
            transform.localScale = Vector3.one;
        }

        //Add push vector if any
        moveDelta += pushDirection;
        //reduce the push force every frame based of recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //colliding
        //go to edit->project setting->physics 2d and turn of Queries start in coliders, this way the player doesnt colide with himself

        bool teste = false;
        if(imune){//TODO: trocar para uma cena melhor em vez deste copy paste no if imune
            RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta, moveDelta.magnitude, LayerMask.GetMask("Blocking"));
            if(hit.collider != null)
            {
                if(hit.collider.transform.position.y != transform.parent.position.y)
                {
                    // Obstacle is below or on top, move horizontally
                    Vector2 moveDelta2 = new Vector2(moveDelta.x, 0);
                    RaycastHit2D hit2 = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta2, moveDelta2.magnitude, LayerMask.GetMask("Blocking"));
                    if(hit2.collider == null)
                    {
                        transform.parent.Translate(moveDelta.x, 0, 0);
                        teste = true;
                    }
                }
                if(hit.collider.transform.position.x != transform.parent.position.x && !teste)
                {
                    // Obstacle is on the side, move vertically
                    Vector2 moveDelta2 = new Vector2(0, moveDelta.y);
                    RaycastHit2D hit2 = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta2, moveDelta2.magnitude, LayerMask.GetMask("Blocking"));
                    if(hit2.collider == null)
                    {
                        transform.parent.Translate(0, moveDelta.y, 0);
                    }
                }
            }
            else
            {
                transform.parent.Translate(moveDelta.x, moveDelta.y, 0);
            }
        }else{
            RaycastHit2D hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta, moveDelta.magnitude, LayerMask.GetMask("Characters", "Blocking"));
            if(hit.collider != null)
            {
                if(hit.collider.transform.position.y != transform.parent.position.y)
                {
                    // Obstacle is below or on top, move horizontally
                    Vector2 moveDelta2 = new Vector2(moveDelta.x, 0);
                    RaycastHit2D hit2 = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta2, moveDelta2.magnitude, LayerMask.GetMask("Characters", "Blocking"));
                    if(hit2.collider == null)
                    {
                        transform.parent.Translate(moveDelta.x, 0, 0);
                        teste = true;
                    }
                }
                if(hit.collider.transform.position.x != transform.parent.position.x && !teste)
                {
                    // Obstacle is on the side, move vertically
                    Vector2 moveDelta2 = new Vector2(0, moveDelta.y);
                    RaycastHit2D hit2 = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, moveDelta2, moveDelta2.magnitude, LayerMask.GetMask("Characters", "Blocking"));
                    if(hit2.collider == null)
                    {
                        transform.parent.Translate(0, moveDelta.y, 0);
                    }
                }
            }
            else
            {
                transform.parent.Translate(moveDelta.x, moveDelta.y, 0);
            }
        }
        
        
        
        
    }
}