using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{  
    // Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // Imunity
    public float imuneTime = 1.0f;
    protected float lastImune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReceiveDamage / Die
    // All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImune > imuneTime)
        {
            lastImune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            Debug.Log(pushDirection);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }
    protected virtual void Death()
    {
        Debug.Log("Death was not implemented in "+ this.name);
    }
}