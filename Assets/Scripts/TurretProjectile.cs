using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    
    //just destroys projectile on collision for now
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
