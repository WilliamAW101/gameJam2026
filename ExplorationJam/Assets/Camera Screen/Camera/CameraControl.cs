using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{

    public float rotateSpeed = 600f;

    public float friction = 0.9f;

    public float minVel = 0.1f;

    private Vector2 rotateVel;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rotateVel = Vector2.zero;

        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            CameraOrbit();
            return;
        }

        Debug.Log(rotateVel);

        if (rotateVel.sqrMagnitude < minVel)
        {
            rotateVel = Vector2.zero;
        }

        //friction lerp the velocity
        rotateVel = Vector2.Lerp(rotateVel, Vector2.zero, friction * Time.deltaTime);

        //acpply velocity 
        transform.Rotate(Vector3.right, -rotateVel.y * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateVel.x * Time.deltaTime, Space.World);

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {

        }


    }

    private void CameraOrbit()
    {
        Vector2 mouseVel = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * rotateSpeed;

        float yaw = mouseVel.x * Time.deltaTime;
        float pitch = mouseVel.y * Time.deltaTime;

        transform.Rotate(Vector3.right, -pitch);
        transform.Rotate(Vector3.up, yaw, Space.World);

        if (Input.GetKey(KeyCode.Mouse1) && mouseVel.sqrMagnitude > 0f)
        {
            rotateVel = mouseVel;
        }

        
    }
}
