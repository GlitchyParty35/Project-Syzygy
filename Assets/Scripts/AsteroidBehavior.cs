using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float driftSpeed = 1f;
    public float rotationSpeed = 5f; // Degrees per second
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Apply an initial random drift to the asteroid
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.velocity = randomDirection * driftSpeed;

        // Apply a random rotation speed
        rb.angularVelocity = rotationSpeed * (Random.Range(0, 2) * 2 - 1); // This will apply a random rotation direction
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Calculate the momentum transfer (halved) from the player to the asteroid
            Vector2 momentumTransfer = playerRb.velocity * 0.5f;
            rb.velocity += momentumTransfer;

            // Slow the player by half
            playerRb.velocity *= 0.5f;
        }
    }
}

