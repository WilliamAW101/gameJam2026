using UnityEngine;

public class HighValueLoot : MonoBehaviour
{
    public GameObject Loot;
    public bool clickedOnce = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Loot.SetActive(false);
    }

   public void Unhidden()
    {
        if(!clickedOnce)
        {
            Loot.SetActive(true);
            clickedOnce = true;
        }
        else
        {
            Loot.SetActive(false);
            clickedOnce = (false);
        }
        
    }
}
