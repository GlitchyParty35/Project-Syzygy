using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustBar : MonoBehaviour
{
    private Slider slider;

    public PlayerController player;

    private void Awake()
    {
        slider = GameObject.Find("ThrustBar").GetComponent<Slider>();
    }

    void Update()
    {
        //Thrust up
        if (Input.GetKey(KeyCode.W))
        {
            slider.value += 0.1f;
        }
        //Thrust down
        if (Input.GetKey(KeyCode.S))
        {
            slider.value -= 0.1f;
        }
        
        player.thrust = slider.value;
    }
}
