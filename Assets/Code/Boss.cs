using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject miniumPrefab;
    public OpenDoor door;
    protected bool firstTime = true;

    protected override void Start()
    {
        base.Start();
        hitpoint = 10;
        GameObject child0 = Instantiate(miniumPrefab, transform.position + new Vector3(2,0,0), Quaternion.identity);
        door.AddEnemy(child0);

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(hitpoint<=5 && firstTime){
            firstTime = false;
            transform.GetComponent<SpriteRenderer>().color = Color.red;
            speed +=1;
            GameObject child1 = Instantiate(miniumPrefab, transform.position, Quaternion.identity);
            child1.GetComponent<Transform>().localPosition = new Vector3(2, 0, 0);
            door.AddEnemy(child1);
            GameObject child2 = Instantiate(miniumPrefab, transform.position, Quaternion.identity);
            child2.GetComponent<Transform>().localPosition = new Vector3(-2, 0, 0);
            door.AddEnemy(child2);
        }
    }
}
