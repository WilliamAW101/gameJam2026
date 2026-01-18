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

    void Start()
    {
        satelliteThruster = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
    void FixedUpdate()
    {
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
                resourceTracker.Instance.useFuel(1);
            }
            else
            {
                Debug.LogError("Resource Tracker instance is null!");
            }
        }
    }
    
    public void rotateSatellite()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90f);
    }
    
    public void thrustForward(float thrustForce)
    {
        satelliteThruster.AddForce(transform.up * thrustForce);
        
    }
}