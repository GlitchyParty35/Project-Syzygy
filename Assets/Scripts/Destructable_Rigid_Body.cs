using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_Rigid_Body : MonoBehaviour
{

    [SerializeField]
    float forceLevel;

    [SerializeField]
    Vector3 dir; //dir for piece to travel in. Will be slightly randomized
    [SerializeField]
    float torque; //a random level will be generated based on this as the highest and lowest possible value

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dir);
        dir.x = Random.Range(dir.x, dir.x * 1.5f);
        dir.y = Random.Range(dir.y, dir.y * 1.5f);
        forceLevel = Random.Range(forceLevel, forceLevel * 1.5f);
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddRelativeForce(dir * forceLevel, ForceMode2D.Impulse);
        rb2d.AddTorque(Random.Range(-torque, torque));
        StartCoroutine(deleteComponent());
    }

    public IEnumerator deleteComponent()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        Destroy(gameObject);
    }
}
