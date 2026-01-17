using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{

    public float rotateSpeed = 600f;

    public float friction = 0.9f;

    public float minVel = 0.1f;

    public float maxVel = 1000f;

    private float zoomMin = -8f;
    private float zoomMax = -4f;
    private float currentZoom = -4f;
    private float startingZoom = -100f;

    private float padding;

    public Camera camera;

    public GameObject planet;

    public bool zoomedIn = false;
    public bool started = false;

    public bool foVisible = false;

    public Transform CamTransform;
    private Vector2 rotateVel;

    public GameObject[] taggedObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float radius = planet.GetComponent<SphereCollider>().radius;
        float size = planet.transform.localScale.x;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        padding = -1 * (radius * size);

        currentZoom = startingZoom + padding;
        startingZoom = startingZoom + padding;
        zoomMin = zoomMin + padding;
        zoomMax = zoomMax + padding;

    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();

        if (started == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rotateVel = Vector2.zero;
            
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            CameraOrbit();
            return;
        }

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
            rotateVel = Vector2.ClampMagnitude(mouseVel,maxVel);
        }

        
    }

    private void CameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (currentZoom == startingZoom && scroll > 0f)
        {
            if (started == false)
            {
                currentZoom = zoomMin;
                started = true;
            }

            FoVisible(false);

            foVisible = false;
        }
        else if (scroll > 0f)
        {
            //Zoomed in all the way
            currentZoom = zoomMax;
            if (started == false)
            {
                started = true;
            }

            FoVisible(true);
        }
        else if (currentZoom == zoomMin && scroll < 0f)
        {
            if (started == true)
            {
                currentZoom = startingZoom;
                started = false;
            }

            FoVisible(false);
        }
        else if (scroll < 0f)
        {
            currentZoom = zoomMin;
            if (started == false)
            {
                started = true;
            }

            FoVisible(false);
        }

        

        Vector3 camlocalPos = camera.transform.localPosition;
        camlocalPos.z = Mathf.Lerp(camlocalPos.z, currentZoom, 10f * Time.deltaTime);
        camera.transform.localPosition = camlocalPos ;
    }


    public void FoVisible(bool trfl)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Findable");

        if (foVisible == !trfl)
        {
            Debug.Log(taggedObjects.Length);
            foreach (GameObject obj in taggedObjects)
            {
                    
                    MeshRenderer foRend = obj.GetComponent<MeshRenderer>();
                    foRend.enabled = trfl;

            }
            foVisible = trfl;
        }
    }
}
