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
            GameObject mini1 = Instantiate(miniumPrefab, transform.position, Quaternion.identity);          
            door.AddEnemy(mini1);
            GameObject mini2 = Instantiate(miniumPrefab, transform.position, Quaternion.identity);
            door.AddEnemy(mini2);

            if(GameManager.instance.playerWrapper.transform.position.x < transform.position.x - 4 && GameManager.instance.playerWrapper.transform.position.x > transform.position.x + 4){
                mini1.GetComponent<Transform>().position = transform.position + new Vector3(-2, 0, 0);
                mini2.GetComponent<Transform>().position =  transform.position + new Vector3(2, 0, 0);
            }else{
                mini1.GetComponent<Transform>().position = transform.position + new Vector3(0, 2, 0);
                mini2.GetComponent<Transform>().position =  transform.position + new Vector3(0, -2, 0);
            }
        }
    }
}
