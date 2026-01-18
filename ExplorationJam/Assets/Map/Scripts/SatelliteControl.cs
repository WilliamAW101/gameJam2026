using Unity.VisualScripting;
using UnityEngine;

public class SatelliteControl : MonoBehaviour
{
    [SerializeField] float thrustForce;
    private Rigidbody satelliteThruster;
    [SerializeField] OrbitPlanet orbitplanet;
    
    void Start()
    {
        satelliteThruster = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rotateSatellite();
        
        if (Input.GetKey(KeyCode.W))
        {
            thrustForward(thrustForce);
        }
        
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