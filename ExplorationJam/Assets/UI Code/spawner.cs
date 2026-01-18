using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject meteorPrefab;

    [SerializeField] private Vector2 xRange = new Vector2(-600f, -400f);
    [SerializeField] private Vector2 yRange = new Vector2(25f, 65f);
    [SerializeField] private Vector2 zRange = new Vector2(400f, 500f);


    [SerializeField]
    private float meteorInterval = 3.5f;


    void Start()
    {
        StartCoroutine(spawnMeteor(meteorInterval, meteorPrefab));
    }

    private IEnumerator spawnMeteor(float interval, GameObject Meteor)
    {
        yield return new WaitForSeconds(interval);

        Vector3 randomPosition = new Vector3(
            Random.Range(xRange.x, xRange.y),
            Random.Range(yRange.x, yRange.y),
            Random.Range(zRange.x, zRange.y)
        );

        Instantiate(Meteor, randomPosition, Quaternion.identity);

        StartCoroutine(spawnMeteor(interval, Meteor));
    }



}
