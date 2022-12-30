using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4;
    protected BoxCollider2D collider2d;
    protected RaycastHit2D hit;
    float x;
    float y;

    protected void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        //get the input(maybe trade with button insted of horizi«ontal and vertical)
        x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        // Limit the player's movement to one direction at a time
        if (x != 0 && y != 0)
        {
            x = x*Mathf.Sqrt(2)/2;
            y = y*Mathf.Sqrt(2)/2;
        }
        //rotate the sprite, change with rwin stick funcionality
        if(x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(x > 0)
        {
            transform.localScale = Vector3.one;
        }
        //colliders
        //go to edit->project setting->physics 2d and turn of Queries start in coliders, this way the player doesnt colide with himself
        hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, new Vector2(x, 0), Mathf.Abs(x), LayerMask.GetMask("Characters", "Blocking"));
        if(hit.collider == null)
        {
            transform.Translate(x, 0, 0);
        }
        hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, new Vector2(0, y), Mathf.Abs(y), LayerMask.GetMask("Characters", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, y, 0);
        }
    }
}