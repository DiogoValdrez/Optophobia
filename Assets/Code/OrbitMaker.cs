using UnityEngine;
using System.Collections.Generic;

public class OrbitMaker : MonoBehaviour//Collectable
{
    public GameObject prefab1;
    protected float r = 0.8f;
    protected List<GameObject> Orbiting = new List<GameObject>();


    //public GameObject prefab2;

    //TODO: Think on where to put this, maybe on the pick up(use the chest code)
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GameObject prefabToInstantiate;
    //     if (collision.gameObject.CompareTag("Tag1"))
    //     {
    //         prefabToInstantiate = prefab1;
    //     }
    //     else if (collision.gameObject.CompareTag("Tag2"))
    //     {
    //         prefabToInstantiate = prefab2;
    //     }
    //     else
    //     {
    //         return;
    //     }

    //     GameObject child = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity, transform);
    //     child.GetComponent<OrbitMotor>().orbitSpeed = orbitSpeed;
    // }
    protected virtual void Start()
    {
        //base.Start();

        // CreatObjectInOrbit(prefab1, new Vector3(r, 0, 0));
        // CreatObjectInOrbit(prefab1, GetNextPosition(new Vector3(r, 0, 0)));
        // CreatObjectInOrbit(prefab1, GetNextPosition(GetNextPosition(new Vector3(r, 0, 0))));
        //RemoveObjectInOrbit(GetComponentInChildren<OrbitMotor>().gameObject);
    }

    protected virtual void Update(){
        while(Orbiting.Count < GameManager.instance.player.hitpoint){
            if(Orbiting.Count == 0){
                CreatObjectInOrbit(prefab1, new Vector3(r, 0, 0));
            }
            CreatObjectInOrbit(prefab1, GetNextPosition(Orbiting[Orbiting.Count-1].transform.localPosition));
        }
        while(Orbiting.Count > GameManager.instance.player.hitpoint){
            RemoveLastObjectInOrbit();
        }
    }

    protected void CreatObjectInOrbit(GameObject prefab, Vector3 position)
    {
        GameObject child = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        child.GetComponent<Transform>().localPosition = position;
        Orbiting.Add(child);
        //Orbiting.ForEach(Debug.Log);

    }

    public void RemoveObjectInOrbit(GameObject child)
    {
        Orbiting.Remove(child);
        Destroy(child);
        GameManager.instance.player.hitpoint -=1;
        if(GameManager.instance.player.hitpoint <= 0)
        {
            GameManager.instance.player.Death();
        }
    }

    public void RemoveLastObjectInOrbit(){
        Destroy(Orbiting[Orbiting.Count-1]);
        Orbiting.RemoveAt(Orbiting.Count-1);
    }

    Vector3 GetNextPosition(Vector3 lastPos)
    {
        
        float theta = Mathf.Asin(lastPos.y/r) + Mathf.PI/6;
        float x = r*Mathf.Cos(theta);//2*Mathf.PI/3);
        float y = r*Mathf.Sin(theta);//2*Mathf.PI/3);
        return new Vector3(x, y, 0);
    }
}
