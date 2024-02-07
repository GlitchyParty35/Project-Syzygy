using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust;
    Vector2 lastVelocity;
    bool launched = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //most recent velocity
        lastVelocity = rb.velocity;

        //Only accept input if ship has not been launched
        if(!launched)
        {
            //Launch when space is down
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("launch");
                rb.AddForce(transform.up * thrust);
                launched = true;
            }
            //Rotate left when A is down
            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 2f);
            }
            //Rotate right when D is down
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - 2f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Reflects the angle of the ships velocity
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);     
        rb.velocity = direction * speed;

        //Ship starts spinning after collision and I don't know why but this fixes it
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}