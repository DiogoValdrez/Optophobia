using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Speed at which the object should rotate towards the mouse
    public float rotationSpeed = 10.0f;
    protected Vector3 lastAng;
    // protected RaycastHit2D hit;
    // protected BoxCollider2D collider2d;


    // protected void Start()
    // {
    //     collider2d = GetComponentInChildren<BoxCollider2D>();
    // }

    void Update()
    {
        lastAng = transform.rotation.eulerAngles;
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calculate the angle between the object and the mouse
        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle - 90)), rotationSpeed * Time.deltaTime);

        // // Use a BoxCast to check if the object will collide with another object when it rotates
        // //hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1],0), collider2d.size, 0, Vector2.zero, 0, LayerMask.GetMask("Blocking"));
        // hit = Physics2D.BoxCast(transform.position + new Vector3(collider2d.offset[0], collider2d.offset[1], 0), collider2d.size, 0, new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)), 0.1f, LayerMask.GetMask("Blocking"));

        // if (hit.collider == null){
        //     // Rotate the object towards the mouse
        //     transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle - 90)), rotationSpeed * Time.deltaTime);
        // }else{
        //     Debug.Log("Will collide");
        // }     

        if(((transform.rotation.eulerAngles - lastAng).magnitude / Time.deltaTime)>100){
            Debug.Log((transform.rotation.eulerAngles - lastAng).magnitude / Time.deltaTime);
        }
        
    }
}
