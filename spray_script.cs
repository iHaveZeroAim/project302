// When in Use(), it tells the particle system attached to play
// as well as check for raycast collisions for a glass slide object
// which then checks for state and then changes if true

using UnityEngine;
using System.Collections;

public class spray_script : usable_script {
    RaycastHit hit;
    public GameObject exit;
    public float length;
    public ParticleSystem particles;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.DrawRay(exit.GetComponent<Transform>().position, exit.GetComponent<Transform>().forward * length, Color.red);
    }

    public override void Use()
    {
        particles.Play();
        Physics.Raycast(exit.GetComponent<Transform>().position, exit.GetComponent<Transform>().forward, out hit, length);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Slide")
            {
                // TODO : check for state
                hit.collider.GetComponent<fusion>().change();
            }
        }
    }

    public override void Stop()
    {
        particles.Stop();
    }
}
