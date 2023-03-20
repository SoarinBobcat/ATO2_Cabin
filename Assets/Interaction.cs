using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform t_cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.DrawRay(t_cam.position, t_cam.forward * 3, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(t_cam.position, t_cam.forward, out hit, 3))
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
