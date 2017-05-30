// Creates a droplet upon Use()
// Gives the droplet_script the variables by string

using UnityEngine;
using System.Collections;

public class dropper_script : usable_script {

    public GameObject droplet;
    public string substance;
    public Transform nozzle;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public override void Use()
    {
        GameObject dropletInstance;
        dropletInstance = (GameObject)Instantiate(droplet, nozzle.position, nozzle.rotation);
        dropletInstance.GetComponent<droplet_script>().setSubstance(substance);
    }

    public override void Stop()
    {
        
    }
}
