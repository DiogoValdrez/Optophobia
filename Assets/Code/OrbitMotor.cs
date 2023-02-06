using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbitMotor : MonoBehaviour //TODO: MAke inherit from orbit make so you can destoi gameobject and remove from list
{
    public Transform target;
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
            speed = GameManager.instance.orbitSpeed;
        }else if(x < 0){
            speed = -GameManager.instance.orbitSpeed;
        }
        if(!PauseMenu.GameIsPaused && SceneManager.GetActiveScene().name != "MainMenu")
        {
            transform.RotateAround(target.position, zAxis, speed);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
    protected void ReceiveDamage(Damage dmg)
    {
        GetComponentInParent<OrbitMaker>().RemoveObjectInOrbit(gameObject);
        //RemoveObjectInOrbit(gameObject);
    }
}