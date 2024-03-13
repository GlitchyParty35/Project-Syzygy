using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_Rigid_Body : MonoBehaviour
{

    [SerializeField]
    float forceLevel;

    [SerializeField]
    Vector3 dir;
    [SerializeField]
    float torque;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 dir = -transform.right + transform.up;
        Debug.Log(dir);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddRelativeForce(dir * forceLevel, ForceMode2D.Impulse);
        rb2d.AddTorque(torque);
    }
}
