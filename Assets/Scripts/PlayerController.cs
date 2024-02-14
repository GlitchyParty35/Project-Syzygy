using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialThrust = 5f;
    public float maxThrust = 10f;
    public float rotationSpeed = 100f;
    public float cooldownTime = 2f; // Cooldown time in seconds before the ship can launch again

    private float thrust;

    private Vector2 lastVelocity;
    private bool canLaunch = true;
    private float cooldownTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thrust = initialThrust;
    }

    void Update()
    {
        // Track the ship's most recent velocity
        lastVelocity = rb.velocity;

        // Cooldown timer to control re-launch availability
        if (!canLaunch)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                canLaunch = true;
                cooldownTimer = 0;
            }
        }

        // Only accept input if ship has not been launched
        if (canLaunch)
        {
            // Increase thrust while holding down space, up to a maximum
            if (Input.GetKey(KeyCode.Space))
            {
                thrust = Mathf.Min(thrust + Time.deltaTime * initialThrust, maxThrust);
            }

            // Launch when space is released
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canLaunch = false;
                rb.drag = 0.5f; // Adjust drag for gameplay
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                thrust = initialThrust; // Reset thrust after launch
            }

            // Smooth rotation control
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -rotation);
        }
        else
        {
            // Adjust drag based on velocity to simulate space friction or resistance
            rb.drag = rb.velocity.magnitude > 0.1 ? 0.1f : 1f;
        }
    }

        public float Thrust
    {
        get { return thrust; }
        set { thrust = Mathf.Clamp(value, 0, maxThrust); } // Ensure thrust stays within expected bounds
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Reflects the angle of the ship's velocity and simulates a bounce effect
        var speed = lastVelocity.magnitude;
        var direction = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);     
        rb.velocity = direction * Mathf.Max(speed, 1); // Ensure there's always some movement after collision

        // Corrects ship's rotation to match the new direction
        AdjustRotationAfterCollision(direction);
    }

    private void AdjustRotationAfterCollision(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
