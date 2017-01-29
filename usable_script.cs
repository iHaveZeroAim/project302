// An abstract class in which all usable objects derive from
// All child classes implement their own functions declared here
// This separates the using object functions from the main body
// of code to allow easier maintenance and change as well as cleaner
// code in the main framework
// Objects with this script attached are marked as usable (regardless of
// being pickup-able)

using UnityEngine;
using System.Collections;

public class usable_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // What the object will do upon activation
    public virtual void Use() { }
    // What the object will do upon deactivation
    public virtual void Stop() { }
}
