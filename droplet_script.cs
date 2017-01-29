// This class holds information for a droplet
// It creates a sphere object that is given variables
// by the dropper_script via a string (can be changed)
// and is has a collider component set to trigger mode
// It destroys upon contact with another collider or
// after 1 second of falling.
// Collision checks are done here after checking the 
// other collider and then proceeding to check the state
// if it is the correct game object (glass slide)
// It will then call a change function in the glass slide

using UnityEngine;
using System.Collections;

public class droplet_script : MonoBehaviour {

    private string substance;

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string getSubstance()
    {
        return substance;
    }

    public void setSubstance(string s)
    {
        substance = s;
    }

    void OnTriggerEnter(Collider c)
    {
        Destroy(this.gameObject);
        if(c.GetComponent<Collider>().tag == "Slide")
        {
            // check for state and do something
        }
    }
}
