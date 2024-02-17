using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;
    public GameObject projectile; 
    public Transform spawnPos;
    public float launchSpeed;
    public float maxCoolDown;
    
    
    private float cooldownTime;
    private bool coolingDown = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //sets player as target
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction; //look towards target

        if (!coolingDown)
        {
            {
                Debug.Log("fired");
                GameObject bullet = Instantiate(projectile, spawnPos.position, transform.rotation); //spawn projectile

                bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * launchSpeed); //addforce to projectile

                coolingDown = true;
                cooldownTime = maxCoolDown;
            }
        }
        else
        {
            cooldownTime -= Time.deltaTime;
            if (cooldownTime <= 0)
            {
                coolingDown = false;
            }
        }
    }


}
