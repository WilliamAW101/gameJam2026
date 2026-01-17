using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] GameObject[] planets;
    
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }
    
    void FixedUpdate()
    {
        applyGravity();
    }
    
    public void applyGravity()
    {
        foreach (GameObject planet in planets)
        {
            Planet planetScript = planet.GetComponent<Planet>();
            Vector3 offset = planet.transform.position - transform.position;
            offset.z = 0;
            float magsqr = offset.sqrMagnitude;
            
            if (magsqr > 0.0001f)
            {
                GetComponent<Rigidbody>().AddForce(planetScript.gravityStrength * offset.normalized * GetComponent<Rigidbody>().mass / magsqr);
            }
        }
    }
}