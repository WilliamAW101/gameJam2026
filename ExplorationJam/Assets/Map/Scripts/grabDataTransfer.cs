using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class grabDataTransfer : MonoBehaviour
{
    [SerializeField] Button backButton;
    private GameObject DataTransfer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataTransfer = GameObject.Find("DataTransfer");
        backButton.onClick.AddListener(() => backToMap(DataTransfer));
    }
    void backToMap(GameObject DataTransfer)
    {
        Transitions.Instance.ToMapTransition();
    }
}
