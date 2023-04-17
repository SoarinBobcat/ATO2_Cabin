using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    int spd = 4;
    Vector3 currSpd = Vector3.zero;

    float x_move = 0f;
    float z_move = 0f;

    public CharacterController Capsule;
    LayerMask mask;
    public Transform t_cam;
    public GameObject TextBox;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        Capsule = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input and calculate speed
        x_move = Input.GetAxis("Horizontal")*spd*Time.deltaTime;
        z_move = Input.GetAxis("Vertical")*spd*Time.deltaTime;
        
        //Put input into a Vector3
        currSpd = (transform.forward * z_move) + (transform.right *x_move);
        
        //Apply Speed
        Capsule.Move(currSpd);

        //Interaction
        if (Input.GetButton("Fire1"))
        {
            Debug.DrawRay(t_cam.position, t_cam.forward * 2, Color.red);
            RaycastHit hit;
            //Fire a raycast and get the interactable's tag
            if (Physics.Raycast(t_cam.position, t_cam.forward, out hit))
            {
                switch (hit.collider.tag) {
                    //Toilet Interaction
                    case ("Toilet"):
                        TextBox.SetActive(true);
                        txt.text = "Toilet with top of the line spinning functionality!";
                        break;
                    //Bed Interaction
                    case ("Bed"):
                        TextBox.SetActive(true);
                        txt.text = "A super comfy bed with tons of space for hiding your life savings!";
                        break;
                    //Table Interaction
                    case ("Table"):
                        TextBox.SetActive(true);
                        txt.text = "This kitchen has all the fundamentals of a normal kitchen! (gas not included)";
                        break;
                }
            }
        }

        LayerMask mask = LayerMask.GetMask("Interactable");

        //Check if a text box is active and deactivate it if the player moves away from the interactable
        if (TextBox.activeSelf)
        {
            if (!Physics.CheckSphere(transform.position, 2, mask))
            {
                TextBox.SetActive(false);
            }
        }
    }
}
