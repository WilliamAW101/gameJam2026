using UnityEditorInternal;
using UnityEngine;

public class SatelliteControl : MonoBehaviour
{
    [SerializeField] float thrustForce;
    private Rigidbody satelliteThruster;
    [SerializeField] OrbitPlanet orbitplanet;
    [SerializeField] public ParticleSystem ThrusterPart;

    public AudioSource SatelliteAudio;
    public AudioClip ThrusterSound;
    public AudioClip ThrusterRelease;

    const int fuelUsage = 1;
    const int Earth = -1;

    void Start()
    {
        satelliteThruster = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // we want to make sure we know that planet we are at, -1 for if we are not at a planet (that is Earth)
        if (orbitplanet.getIsAPlanet() == true)
        {
            // Debug.Log(orbitplanet.getCurrentPlanetID());
            if (Transitions.Instance != null)
            {
                Transitions.Instance.setPlanetIndex(orbitplanet.getCurrentPlanetID());
            }
            else
            {
                Debug.LogError("Bloody instance is null");
            }
        }
        else 
            Transitions.Instance.setPlanetIndex(Earth);
    }
    void FixedUpdate()
    {   
        // for controlling the satellite
        rotateSatellite();

        if (Input.GetKeyUp(KeyCode.W))
        {
            ThrusterPart.Stop();
            SatelliteAudio.PlayOneShot(ThrusterSound);
        }

        if (Input.GetKeyDown(KeyCode.W) && ThrusterPart.isPlaying == false)
        {
            ThrusterPart.Play();
            SatelliteAudio.clip = ThrusterSound;
            SatelliteAudio.Play();
        }

        if (Input.GetKey(KeyCode.W))
        {
            thrustForward(thrustForce);
            if (resourceTracker.Instance != null)
            {
                resourceTracker.Instance.useFuel(fuelUsage);
            }
            else
            {
                Debug.LogError("Resource Tracker instance is null!");
            }
        }
        
        // basically if the satellite is at the planet, and the user presses space, then we can go to the planet scene
        if (orbitplanet.getIsAPlanet() == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log(orbitplanet.getCurrentPlanetID());
                
                if (Transitions.Instance != null)
                {
                    Transitions.Instance.ToCameraTransition(orbitplanet.getCurrentPlanetID());
                }
                else
                {
                    Debug.LogError("Bloody instance is null");
                }
            }
        }
    }
    
    public void rotateSatellite()
    {
        // following the cursor
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90f);
    }
    
    public void thrustForward(float thrustForce)
    {
        // method just adds an upward force to the satellite, since we have no gravity, we can do this
        satelliteThruster.AddForce(transform.up * thrustForce);
        
    }
}