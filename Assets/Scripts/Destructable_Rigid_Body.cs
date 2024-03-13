using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_Rigid_Body : MonoBehaviour
{

    [SerializeField]
    Vector2 forceDirection;

    [SerializeField]
    float torque;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection);
        rb2d.AddTorque(torque);
    }
}
