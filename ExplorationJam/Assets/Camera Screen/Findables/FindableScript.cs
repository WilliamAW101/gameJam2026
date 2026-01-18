using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FindableScore : MonoBehaviour
{
    public GameObject CraterFo;
    public GameObject PyramidFo;
    public GameObject AlienFo;
    public GameObject RuinsFo;
    public GameObject MountainFo;

    public int FoScore;
    public bool found;
    //Reference Master Script for Score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FoScore = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
