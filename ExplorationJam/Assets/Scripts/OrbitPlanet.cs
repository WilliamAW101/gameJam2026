using UnityEngine;

public class OrbitPlanet : MonoBehaviour
{
    [SerializeField] float orbitSpeed = 80f;
    Rigidbody satelliteVel;
    private Vector3 lastVelocity;
    private bool isAtPlanet = false, leavingPlanetFlag = false;
    private GameObject planet;
    private Transform planetTransform;
    private float timer;
    void Start()
    {
        satelliteVel = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isAtPlanet)
        {
            transform.RotateAround(planetTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
            lastVelocity = satelliteVel.linearVelocity;
        }

        if (leavingPlanetFlag)
        {
            timer += Time.deltaTime;
            if (timer > 2.0f)
            {
                leavingPlanet();
                leavingPlanetFlag = false;
                timer = 0f; // reset timer
            }
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Satellite is near planet");
            planet = other.gameObject;
            planetTransform = planet.transform;
            isAtPlanet = true;
            timer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Satellite is leaving planet");
            leavingPlanetFlag = true;
        }
    }

    private void leavingPlanet()
    {
        isAtPlanet = false;
        planet = null;
        planetTransform = null;
        satelliteVel.linearVelocity = lastVelocity;
    }
}