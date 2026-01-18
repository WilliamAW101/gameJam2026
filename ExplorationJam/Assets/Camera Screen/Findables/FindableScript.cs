using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FindableScripts : MonoBehaviour
{
    public GameObject CraterFo;
    public GameObject PyramidFo;
    public GameObject AlienFo;
    public GameObject RuinsFo;
    public GameObject MountainFo;

    public GameObject[] foList;

    public int ScoreTotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foList = new GameObject[] { CraterFo, PyramidFo, AlienFo, RuinsFo, MountainFo };
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addToScore()
    {
        
    }
}
