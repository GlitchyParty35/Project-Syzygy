using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialThrust = 5f;
    public float maxThrust = 50f;
    public float rotationSpeed = 100f;
    public float cooldownTime = 4f; // Cooldown time in seconds before the ship can launch again
    
    //Probably a better way of accessing UI elements than this 
    public ThrustBar thrustMeter; //Thrust bar UI
    public LaunchButton launchButton; //Launch Button UI

    private Vector2 lastVelocity;
    private bool canLaunch = true;
    private float thrust;
    private float cooldownTimer;

    // Private field for thrust with a public property to access and modify it
    private float _thrust;
    public float Thrust
    {
        get { return _thrust; }
        set { _thrust = Mathf.Clamp(value, 0, maxThrust); } // Ensure thrust stays within expected bounds
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _thrust = initialThrust; // Initialize _thrust with initialThrust value
    }

    void Update()
    {
        // Track the ship's most recent velocity for use in collision reflection
        lastVelocity = rb.velocity;

        // Cooldown timer to control re-launch availability
        if (!canLaunch)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                canLaunch = true;
                launchButton.LaunchState(canLaunch); //Update launch button UI
                cooldownTimer = 0;
            }
        }

        // Only accept input if the ship has not been launched
        if (canLaunch)
        {
            // Increase thrust while holding down space, up to a maximum
            if (Input.GetKey(KeyCode.Space))
            {
                _thrust = Mathf.Min(_thrust + Time.deltaTime * initialThrust * 4, maxThrust);
                thrustMeter.updateMeter(_thrust); //Update the level of the UI meter to show thrust power
            }

            // Launch when space is released
            if (Input.GetKeyUp(KeyCode.Space))
            {
                canLaunch = false;
                launchButton.LaunchState(canLaunch); //Update launch button UI
                thrustMeter.updateMeter(0); //Reset thrust meter display after launch
                rb.drag = 0.5f; // Adjust drag for gameplay
                rb.AddForce(transform.up * _thrust, ForceMode2D.Impulse);
                _thrust = initialThrust; // Reset _thrust after launch
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Wall"))
        {
            // Reflects the angle of the ship's velocity and simulates a bounce effect
            var speed = lastVelocity.magnitude;
            var direction = Vector2.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 1); // Ensure there's always some movement after collision

            // Corrects ship's rotation to match the new direction
            AdjustRotationAfterCollision(direction);
        }
    }

    private void AdjustRotationAfterCollision(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
