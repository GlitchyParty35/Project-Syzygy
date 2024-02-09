using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust;
    Vector2 lastVelocity;
    bool canLaunch = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //most recent velocity
        lastVelocity = rb.velocity;

        //Only accept input if ship has not been launched
        if(canLaunch)
        {
            //Launch when space is pressed
            if (Input.GetKeyDown("space"))
            {
                canLaunch = false;
                rb.drag = 0.5f;
                //Impulse to apply force once rather than over time
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);

            }
            //Rotate left when A is down
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 0.5f);
            }
            //Rotate right when D is down
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - 0.5f);
            }
        }
        else
        {
            if(rb.velocity == Vector2.zero)
            {
                Debug.Log("CanLaunch");
                canLaunch = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Reflects the angle of the ships velocity
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);     
        rb.velocity = direction * speed;
        rb.drag = 1;

        //Ship starts spinning after collision and I don't know why but this fixes it
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}