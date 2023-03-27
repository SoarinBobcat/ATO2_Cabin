using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int spd = 4;
    Vector3 currSpd = Vector3.zero;

    float x_move = 0f;
    float z_move = 0f;

    public CharacterController Capsule;

    // Start is called before the first frame update
    void Start()
    {
        Capsule = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        x_move = Input.GetAxis("Horizontal")*spd*Time.deltaTime;
        z_move = Input.GetAxis("Vertical")*spd*Time.deltaTime;

 
        currSpd = (transform.forward * z_move) + (transform.right *x_move);
        


        Capsule.Move(currSpd);
    }
}
