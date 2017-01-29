// Main player code in which the basic framework of the game resides

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class raycastscript : MonoBehaviour
{
    // Results of the raycast: the collider it hits
    private RaycastHit Hit;
    // dist = ray draw distance
    public float dist;
    // holdDist is the distance at which the player holds the object at
    public float holdDist;
    // smooth the movement of the object as it's held
    public float smooth;

    // The canvas text in which the crosshair and contextual text reside
    public Text target;

    // quit menu popup canvas and buttons
    public Canvas quitMenu;
    public Button yesButton;
    public Button exitButton;

    // store the carried object information
    GameObject carriedObject;
    bool carrying;

    // Use this for initialization
    void Start()
    {
        //target = GameObject.Find("Text").GetComponent<Text>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        yesButton = yesButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        // disable quit popup
        quitMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Escape re enables the quit menu and disables firstpersoncontroller to allow the player to use the cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitMenu.enabled = true;
            Cursor.visible = true;
            gameObject.GetComponentInParent<FirstPersonController>().enabled = false;
        }


        // Debug ray, both functions do the same thing
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(this.transform.position, this.transform.forward * dist, Color.red);

        // main carrying code which calls carry() as well as the Use() and Stop() functions upon clicking the buttons
        if (carrying)
        {
            if (carriedObject == null)
            {
                carrying = false;
                return;
            }
            carry(carriedObject);
            if (Input.GetMouseButtonDown(0))
                drop();

            // Right click press
            if(Input.GetMouseButtonDown(1))
            {
                if(carriedObject.GetComponent<usable_script>() != null)
                {
                    carriedObject.GetComponent<usable_script>().Use();
                }
            }
            // Right click de press
            if(Input.GetMouseButtonUp(1))
            {
                if (carriedObject.GetComponent<usable_script>() != null)
                {
                    carriedObject.GetComponent<usable_script>().Stop();
                }
            }
        }
        else
        {
            pickup();
        }
    }

    // Position the object infront of the player and rotate it based on the camera's postion and rotation.
    void carry(GameObject o)
    {
        o.gameObject.GetComponent<Rigidbody>().useGravity = false;
        o.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(o.transform.position, this.transform.position + this.transform.forward * holdDist, Time.deltaTime + smooth));
        o.GetComponent<Rigidbody>().MoveRotation(this.transform.rotation);
    }

    // Create a raycast and check for collisions
    // If 'left click' and ray is colliding with a 'interactable' object 
    // then store the object returned by the raycast as carriedObject 
    // and be 'carrying' an object
    void pickup()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out Hit, dist))
        {
            if(Hit.collider.GetComponent<interact>() != null)
            {
                Hit.collider.GetComponent<interact>().selected();
                target.GetComponent<popup>().display();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if(Hit.collider.GetComponent<interact>() != null)
                {
                    carry(Hit.collider.gameObject);
                    carrying = true;
                    carriedObject = Hit.collider.gameObject;
                }
            }
            // right click interaction without holding i.e. unmovable objects such as the bunsen burner
            if (Input.GetMouseButtonDown(1))
            {
                if (Hit.collider.tag == "unmovable")
                {
                    Hit.collider.GetComponent<usable_script>().Use();
                }
            }
        }
    }

    // Detach the object from player and give it back its gravity
    void drop()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }

    // public implementation of drop() so other classes can cause the object to drop
    public void p_drop(GameObject o)
    {
        if (o == carriedObject)
            drop();
    }

    // Confirm quit game button in quit window ... 
    public void YesPress()
    {
        Application.Quit();
    }

    // ... else disable window again and re enable the controls
    public void NoPress()
    {
        quitMenu.enabled = false;
        Cursor.visible = false;
        gameObject.GetComponentInParent<FirstPersonController>().enabled = true;
    }
}
