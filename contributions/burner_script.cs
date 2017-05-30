// This script is a child of the usable_script
// It implements the Use() and Stop() functions
// by storing a private bool variable which represents
// the state of the burner (on/off)
// as well as holding the particle system and linking
// to the flame_script script to relay the state of the
// burner

using UnityEngine;
using System.Collections;

public class burner_script : usable_script {

    bool On;
    public GameObject flameParticles;
    public GameObject flameTrigger;

	// Use this for initialization
	void Start () 
    {
        On = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void Use()
    {
        if (On == true)
        {
            Stop();
        }
        else
        {
            On = true;
            flameParticles.GetComponent<ParticleSystem>().Play();
            flameTrigger.GetComponent<flame_script>().turnOn();
        }
    }

    public override void Stop()
    {
        On = false;
        flameParticles.GetComponent<ParticleSystem>().Stop();
        flameTrigger.GetComponent<flame_script>().turnOff();
    }
}
