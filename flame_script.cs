// This script handles the collision between the
// fire collision box and the glass slide, making sure
// that the fire is 'on' and that the glass slide is
// in a specific state and then applying a change
// on the glass slide

using UnityEngine;
using System.Collections;

public class flame_script : MonoBehaviour {

    private bool isOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Slide" && isOn)
        {
            // check for state and do something
        }
    }

    public void turnOn()
    {
        isOn = true;
    }

    public void turnOff()
    {
        isOn = false;
    }
}
