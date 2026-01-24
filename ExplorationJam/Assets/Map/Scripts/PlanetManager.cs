using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] GameObject[] planets;
    [SerializeField] GameObject ManagerGameObject;
    [SerializeField] GameObject SatellitePrefab;
    private bool bigOnePlaced = false;
    private GameObject[] placedPlanets = new List<GameObject>().ToArray();

    public static PlanetManager Instance { get; internal set; }

    void Awake()
    {
        GameObject Earth =  Instantiate(planets[0],  new Vector3(0, 0, 0), Quaternion.identity);
        Earth.transform.SetParent(ManagerGameObject.transform, false);
        Earth.transform.localScale = new Vector3(1, 1, 1f);
        GameObject Satellite = Instantiate(SatellitePrefab, new Vector3(0, 3, 0), Quaternion.identity);
        Satellite.transform.SetParent(ManagerGameObject.transform, false);
        Satellite.transform.localScale = SatellitePrefab.transform.localScale;

        // Loop through all planets and instantiate them at random positions, the algorithm below keeps track of the big planet and makes sure it does
        // not spawn at some crappy location. I can explain it if need be but I am too lazy to type it out.
        for (int i = 1; i < planets.Length; i++)
        {
            Vector3 randomPosition;
            if (i == 1)
            {
                randomPosition = new Vector3(randomXVal(i), Random.Range(5, 15), 0);
            }
            else
            {
                randomPosition = new Vector3(randomXVal(i), Random.Range(0, 15), 0);
            }
            int randomPlanetIndex = Random.Range(1, planets.Length);
            if ((randomPlanetIndex == 4 && bigOnePlaced == false) && i != 1)
            {
                bigOnePlaced = true;
            }
            else if (i == 1 || (randomPlanetIndex == 4 && bigOnePlaced == true))
            {
                randomPlanetIndex = Random.Range(1, planets.Length - 1);
            }
            GameObject planet = Instantiate(planets[randomPlanetIndex], randomPosition, Quaternion.identity);
            placedPlanets = placedPlanets.Append(planet).ToArray();
            placedPlanets[i - 1].transform.SetParent(ManagerGameObject.transform, false);
            placedPlanets[i - 1].transform.localScale = planets[randomPlanetIndex].transform.localScale;
            
        }    
    }

    // helper function
    private int randomXVal(int i)
    {
        return 5 + (10 * (i-1)) + Random.Range(-2,2);
    }

    public GameObject[] getPlanets()
    {
        return placedPlanets;
    }
}
