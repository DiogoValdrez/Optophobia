using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Speed at which the object should rotate towards the mouse
    public float rotationSpeed = 10.0f;
    protected Vector3 lastAng;

    void Update()
    {
        lastAng = transform.rotation.eulerAngles;
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calculate the angle between the object and the mouse
        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        // Rotate the object towards the mouse
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle - 90)), rotationSpeed * Time.deltaTime);

        //Debug.Log((transform.rotation.eulerAngles - lastAng).magnitude / Time.deltaTime);
    }
}
