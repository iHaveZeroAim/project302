// Objects with this script attached are marked so that they can be picked up
// This version highlights the object in red and changes the text to inform
// the player of the buttons required.
// It then tells the main player function the object to pick up
// and calls drop if the object collides with the player (bug fix)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interact : MonoBehaviour 
{

    Color default_color;
    private GameObject player;
    bool selecting;
	// Use this for initialization
	void Start () 
    {
        default_color = this.GetComponent<Renderer>().material.color;
        player = GameObject.Find("FirstPersonCharacter");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (selecting)
        {
            
            GetComponent<Renderer>().material.color = Color.red;
            selecting = false;
        }
        else
        {
            GetComponent<Renderer>().material.color = default_color;
        }
	}

    public void selected()
    {
        selecting = true;
    }

    public void OnCollisionEnter(Collision c)
    {
        if(c.collider.tag == "Player")
        {
            player.GetComponent<raycastscript>().p_drop(this.gameObject);
        }
    }
}
