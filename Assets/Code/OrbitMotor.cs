using UnityEngine;

public class OrbitMotor : MonoBehaviour //TODO: MAke inherit from orbit make so you can destoi gameobject and remove from list
{
    public Transform target;
    public float orbitSpeed = 1f;
    protected float speed;
    public Vector3 axis = Vector3.up;
    public float radius = 1f;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    //TODO: Add inheritance
    protected void Start()
    {
        target = transform.parent; 
        //target = GameObject.Find("Player").transform;
    }
    protected void Update()
    {
        speed= 0f;
        float x = Input.GetAxisRaw("Orbit");
        if(x > 0){
            speed = orbitSpeed;
        }else if(x < 0){
            speed = -orbitSpeed;
        }
        if(!PauseMenu.GameIsPaused)
        {
            transform.RotateAround(target.position, zAxis, speed);
        }
        
    }
    protected void ReceiveDamage(Damage dmg)
    {
        GetComponentInParent<OrbitMaker>().RemoveObjectInOrbit(gameObject);
        //RemoveObjectInOrbit(gameObject);
    }
}