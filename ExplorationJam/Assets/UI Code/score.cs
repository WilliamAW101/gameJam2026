using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score : MonoBehaviour
{
    public TMP_Text moneyText;


    int money = 0;
    int total = 300;



    void Start()
    {
        moneyText.text = "Money  " + "$" + money.ToString() +  " / " + "$" + total.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
