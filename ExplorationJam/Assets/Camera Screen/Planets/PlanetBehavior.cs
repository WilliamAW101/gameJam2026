using UnityEngine;
using UnityEngine.UIElements;

public class PlanetBehavior : MonoBehaviour
{
    public GameObject findableObject;

    public SphereCollider SphereCollider;
    public float radius;
    public Vector3 scale;
    public int FoCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        scale = transform.localScale;
        SphereCollider = GetComponent<SphereCollider>();

        radius = SphereCollider.radius * scale.x;

        for (int i = 0; i <= FoCount; i++)
        {
            SpawnOnPlanet();
        }
        
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnOnPlanet()
    {
        
        Vector3 randomDir = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + randomDir * radius;
        Quaternion spawnRotation = Quaternion.LookRotation(randomDir);

        GameObject foinstance = Instantiate(findableObject, spawnPosition, spawnRotation);

        foinstance.transform.localScale = findableObject.transform.localScale;
        foinstance.SetActive(true);
    }
}
