using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Speed at which the object should rotate towards the mouse
    public float rotationSpeed = 10.0f;
    protected Vector3 lastAng;
    protected float attackStartAng;
    protected bool attacking = false;
    protected bool attackPowered = false;

    protected AudioSource audioSource;
    // public AudioClip swingSound;
    public AudioClip hitSound;

    [SerializeField]
    protected float weaponTravel = 0.2f;
    [SerializeField]
    protected int weaponSpeed = 200;

    protected override void Start()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitSound;
    }

    protected override void Update()
    {
        base.Update();

        lastAng = transform.rotation.eulerAngles;
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calculate the angle between the object and the mouse
        float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle - 90)), rotationSpeed * Time.deltaTime);     



        //TODO: Add direction for damage sistem and make less scuffed and add animation to have the feeling of a weapon
        if(((transform.rotation.eulerAngles - lastAng).magnitude / Time.deltaTime)>weaponSpeed){
            if(!attacking){ 
                attackStartAng = Time.fixedTime;
                attacking = true;
                transform.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.blue;//trocar para fazer o getcomponent no start
            }else{
                if((Time.fixedTime - attackStartAng) > weaponTravel){//tentar com distância depois

                    // if(!audioSource.isPlaying)// || audioSource.clip!=swingSound)
                    // {
                    //     audioSource.clip = swingSound;
                    //     audioSource.Play();
                    // } 

                    attackPowered = true;
                    transform.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.red;
                }
            }                
        }else{
            // if(audioSource.clip==swingSound){
            //     audioSource.Pause();
            // }            
            transform.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
            attacking = false;
            attackPowered = false;
        }

    }


    // if((transform.rotation.eulerAngles - attackStartAng).magnitude > 180){//trocar este 100, é suposto ser o travel da arma
    //                 //Debug.Log(transform.rotation.eulerAngles + " + " + attackStartAng +  " + " + (transform.rotation.eulerAngles - attackStartAng).magnitude);
    //                 attackPowered = true;
    //                 Debug.Log("Attack Powered");
                    
    //             }

    protected override void OnColide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            Damage dmg = new Damage
            {
                damageAmount = 1,//damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = 2.0f,//pushForce[weaponLevel]
            };

            if(attackPowered){
                
                audioSource.Play();
                                
                coll.SendMessage("ReceiveDamage", dmg);
            }
        }
        if(coll.tag == "Orbit")
        {
            Damage dmg = new Damage
            {
                damageAmount = 1,//damagePoint[weaponLevel],
                origin = transform.position,
            };

            if(attackPowered){
                
                audioSource.Play();
                
                coll.SendMessage("ReceiveDamage", dmg);
            }
        }
    }
}
