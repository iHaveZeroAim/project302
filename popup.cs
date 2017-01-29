// This script handles the crosshair and updating of prompt text
// upon hovering over interactable objects

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class popup : MonoBehaviour
{
    Text target;
    bool displaying;
    // Use this for initialization
    void Start()
    {
        target = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(displaying)
        {
            target.text = "Press Left click to pick up";
            displaying = false;
        }
        else
        {
            target.text = "+";
        }
    }

    public void display()
    {
        displaying = true;
    }
}