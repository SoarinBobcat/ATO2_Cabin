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
    public GameObject Cursor;
    public GameObject CursorSelect;
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
        LayerMask mask = LayerMask.GetMask("Interactable");

        RaycastHit cursor;
        if (Physics.Raycast(t_cam.position, t_cam.forward, out cursor, 3f))
        {
            if ((cursor.collider.tag == "Toilet") || (cursor.collider.tag == "Bed") || (cursor.collider.tag == "Table"))
            {
                Cursor.SetActive(false);
                CursorSelect.SetActive(true);
            }
            else
            {
                Cursor.SetActive(true);
                CursorSelect.SetActive(false);
            }
        }
        else
        {
            Cursor.SetActive(true);
            CursorSelect.SetActive(false);
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.DrawRay(t_cam.position, t_cam.forward, Color.red);
            RaycastHit hit;
            //Fire a raycast and get the interactable's tag
            if (Physics.Raycast(t_cam.position, t_cam.forward, out hit, 3f))
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

        if (Input.GetButton("Fire2"))
        {
            TextBox.SetActive(false);
        }

        //Check if a text box is active and deactivate it if the player moves away from the interactable
        if (TextBox.activeSelf)
        {
            if ((!Physics.CheckSphere(transform.position, 3, mask)) || (Input.GetButton("Fire2")))
            {
                TextBox.SetActive(false);
            }
        }

        //Closes the game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
