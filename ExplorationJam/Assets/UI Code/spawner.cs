using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject meteorPrefab;

    public GameObject objectToSpawn;

    public Transform spawnLocation;

      



    [SerializeField]
    private float meteorInterval = 3.5f;
    void Start()
    {
        StartCoroutine(spawnMeteor(meteorInterval, meteorPrefab));
    }

    private IEnumerator spawnMeteor(float interval, GameObject Meteor)
    {
        yield return new WaitForSeconds(interval);
        Vector3 specificPosition = new Vector3(-600, Random.Range(25, 65), 449);
        GameObject newMeteor = Instantiate(Meteor, specificPosition, Quaternion.identity);
        StartCoroutine(spawnMeteor(interval, Meteor));
    }

    public void SpawnObjectAtSpecificSpot()
    {
        Quaternion desiredRotation = Quaternion.Euler(0f, 180f, 0f);
        Instantiate(objectToSpawn, spawnLocation.position, desiredRotation);
    }

   
}
