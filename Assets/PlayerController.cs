using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust;
    Vector2 lastVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rb.velocity;

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("launch");
            rb.AddForce(transform.up * thrust);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - 0.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);     
        rb.velocity = direction * speed;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}