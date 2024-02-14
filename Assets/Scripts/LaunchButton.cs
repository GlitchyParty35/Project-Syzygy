using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    //public Image image;
    public bool LaunchOn = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(LaunchOn)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
        }
    }
}
