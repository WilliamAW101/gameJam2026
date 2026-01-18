using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score : MonoBehaviour
{
    public TMP_Text moneyText;

    private TMP_Text Component;

    public TMP_FontAsset newFontAsset;


    int money = 0;
    int total = 300;


    void Awake()
    {
        Component = GetComponent<TMP_Text>();
      
    }

    void Start()
    {
        if (newFontAsset != null && Component != null)
        {
            Component.font = newFontAsset;
        }
        moneyText.text = "$" + money.ToString() +  " / " + "$" + total.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
