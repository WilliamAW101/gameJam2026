using UnityEngine;

public class OrbitPlanet : MonoBehaviour
{
    [SerializeField] float orbitSpeed = 80f;
    Rigidbody satelliteVel;
    // private Vector3 lastVelocity;
    private bool isAtPlanet = false, joiningPlanetFlag = false;
    private GameObject planet;
    private Transform planetTransform;
    private Collider planetCollider;
    private float timer;
    private int currentPlanetID;
    [SerializeField] Transitions transitions;
    void Start()
    {
        satelliteVel = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isAtPlanet)
        {
            transform.RotateAround(planetTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
            // lastVelocity = satelliteVel.linearVelocity;
        }

        if (joiningPlanetFlag)
        {
            timer += Time.deltaTime;
            if (timer > 2.0f)
            {
                joiningPlanet(planetCollider);
                satelliteVel.linearVelocity = Vector3.zero;
                joiningPlanetFlag = false;
                isAtPlanet = true;
                timer = 0f; // reset timer
            }
        }

        if (getIsAPlanet() == true)
        {
            Debug.Log("PRESS SPACE");
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log(getCurrentPlanetID());
                transitions.ToCameraTransition(getCurrentPlanetID());
                {

                }
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            planet = other.gameObject;
            Planet currentPlanet = planet.GetComponent<Planet>();
            currentPlanetID = currentPlanet.getPlanetID();
            Debug.Log("Satellite is near planet");
            planetCollider = other;
            joiningPlanetFlag = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            currentPlanetID = -1;
            Debug.Log("Satellite is leaving planet");
            leavingPlanet();
        }
    }

    private void leavingPlanet()
    {
        isAtPlanet = false;
        planet = null;
        planetTransform = null;
        // satelliteVel.linearVelocity = lastVelocity;
        joiningPlanetFlag = false;
    }

    private void joiningPlanet(Collider other)
    {
        planet = other.gameObject;
        planetTransform = planet.transform;
        isAtPlanet = true;
        timer = 0f;
    }

    public bool getIsAPlanet()
    {
        return isAtPlanet;
    }

    public int getCurrentPlanetID()
    {
        return currentPlanetID;
    }
}