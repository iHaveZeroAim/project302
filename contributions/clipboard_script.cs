///<summary> 
/// This is a child of the usable_script
/// It implements the Use() and Stop() functions
/// to alter the variables in the main player code
/// to adjust the position and rotation of the clipboard
/// object so that it is readable.
/// 
/// This version of the script does not implement a rotation
/// as the main script already does it however the framework
/// of the other version of this project does not rotate
/// and has an updated script in which this does change rotation
/// </summary>

using UnityEngine;
using System.Collections;

public class clipboard_script : usable_script {

    bool reading;

    // Storing information about the main camera to calculate the position and rotation when reading
    // as well as storing the default values is the player wishes to restore the clip board to its default
    GameObject mainCamera;
    Quaternion defaultRotation;
    float defaultDist;

    float newDistance;

	// Use this for initialization
	void Start () 
    {
        newDistance = 1f;

        reading = false;
        mainCamera = GameObject.FindWithTag("MainCamera");
        defaultDist = mainCamera.GetComponent<raycastscript>().holdDist;
	}
    
    // Change the distance at which the object is held during the update cycles by changing the main script's variables
    void Update()
    {
        if(reading)
        {
            mainCamera.GetComponent<raycastscript>().holdDist = newDistance;
        }
    }
	
    // Save the default rotation and then turn reading on
    public override void Use()
    {
        defaultRotation = this.transform.rotation;
        reading = true;
    }

    // Reset rotation and distance
    public override void Stop()
    {
        this.transform.rotation = defaultRotation;
        mainCamera.GetComponent<raycastscript>().holdDist = defaultDist;
        reading = false;
    }
}
