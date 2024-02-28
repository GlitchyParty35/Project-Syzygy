using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyShipController : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private Vector3 myPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        myPosition = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if(rb != null)
            {
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

                // Calculate the momentum transfer (halved) from the player to the asteroid
                Vector2 momentumTransfer = playerRb.velocity * 0.6f;
                rb.velocity += momentumTransfer;

                // Slow the player by half
                playerRb.velocity *= 0.5f;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("ColonyShip"))
        {
            if (rb.velocity.magnitude != 0)
            {
                rb.velocity *= 0;
                Vector3 colPosition = collision.gameObject.transform.position;
                myPosition = colPosition;
                myPosition.x += 2; // Adjust this value as needed for correct positioning
                transform.position = myPosition;
                Destroy(rb); // Consider alternatives to destroying the Rigidbody to avoid potential issues
                transform.parent = collision.gameObject.transform;

                // Notify the GameManager that a ship has been aligned
                GameManager.instance.AddAlignedShip();
            }
        }
    }

}
