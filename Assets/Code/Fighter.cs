using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{  
    // Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 1f;

    // Imunity
    public float imuneTime = 1.0f;
    protected float lastImune;
    public bool imune = false;

    // Push
    protected Vector3 pushDirection;


    public bool ahh = false;
    private float time = 0.0f;

    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImune > imuneTime)
        {
            ahh = true;
            lastImune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
            StartCoroutine(Blink());
        }
    }


    IEnumerator Blink() {
        do {
            imune = true;
            transform.GetComponent<SpriteRenderer>().enabled = !transform.GetComponent<SpriteRenderer>().enabled;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }while (time < imuneTime); 
        transform.GetComponent<SpriteRenderer>().enabled = true;   
        time = 0.0f;
        imune = false;
    }


    //maybe provisorio em public, tenho de trocar quando tiver game manager
    public virtual void Death()
    {
        Debug.Log("Death was not implemented in "+ this.name);
    }
}