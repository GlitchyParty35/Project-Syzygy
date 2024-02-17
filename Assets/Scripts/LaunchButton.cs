using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{

    public void LaunchState(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
        }
    }
}
