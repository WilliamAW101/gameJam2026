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
    public GameObject resourceTracker;
    public GameObject DataTransfer;

    public int ScoreTotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foList = new GameObject[] { AlienFo, CraterFo, PyramidFo, MountainFo, RuinsFo, };
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addToScore()
    {
        
    }
}
