using UnityEngine;
using UnityEngine.UIElements;

public class PlanetBehavior : MonoBehaviour
{
    public GameObject findableObject;
    public Transitions transitions;

    public SphereCollider SphereCollider;
    public Material color;
    public FindableScripts FoManager;
    private GameObject[] foList;

    private GameObject[] spawnedFoList;

    public float radius;
    public Vector3 scale;
    public int FoCount;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        
        
    }
    void Start()
    {
        foList = FoManager.foList;
        scale = transform.localScale;

        SphereCollider = GetComponent<SphereCollider>();

        radius = SphereCollider.radius * scale.y;
        color = GetComponent<Material>();



        for (int i = 0; i <= FoCount; i++)
        {
            Debug.Log(foList.Length);
            int randomFo = Random.Range(0, foList.Length - 1);
            SpawnOnPlanet(foList[randomFo], i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnOnPlanet(GameObject fo, int num)
    {
        
        Vector3 randomDir = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + randomDir * radius;
        Quaternion spawnRotation = Quaternion.LookRotation(randomDir);

        GameObject foinstance = Instantiate(fo, spawnPosition, spawnRotation);

        foinstance.transform.localScale = fo.transform.localScale;

        foinstance.SetActive(true);
    }
}
