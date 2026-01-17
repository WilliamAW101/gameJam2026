using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    public GameObject findableObject;

    public SphereCollider SphereCollider;
    public float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SphereCollider = GetComponent<SphereCollider>();

        radius = SphereCollider.radius;

        SpawnOnPlanet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnOnPlanet()
    {
        
        Vector3 randomDir = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + randomDir * radius;

        GameObject foinstance = Instantiate(findableObject, spawnPosition, Quaternion.identity);

        foinstance.transform.localScale = findableObject.transform.localScale;
        foinstance.SetActive(true);
    }
}
