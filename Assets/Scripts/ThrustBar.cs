using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrustBar : MonoBehaviour
{
    private Slider slider;

    

    private void Awake()
    {
        slider = GameObject.Find("ThrustBar").GetComponent<Slider>();
    }

    public void updateMeter(float newValue) {  slider.value = newValue; }

}
