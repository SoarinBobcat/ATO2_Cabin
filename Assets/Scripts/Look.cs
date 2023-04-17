using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform PlayerCamera;
    public Vector2 sensitivity;

    private Vector2 XYRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MouseInput = new Vector2 {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRot.x -= MouseInput.y * sensitivity.y;
        XYRot.y += MouseInput.x * sensitivity.x;

        XYRot.x = Mathf.Clamp(XYRot.x, -80f, 80f);

        transform.eulerAngles = new Vector3(0, XYRot.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRot.x, 0f, 0f);
    }
}
