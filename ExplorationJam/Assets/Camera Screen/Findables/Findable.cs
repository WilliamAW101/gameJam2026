using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Findable", menuName = "Scriptable Objects/Findable")]
public class Findable : ScriptableObject
{
    

    [SerializeField]
    public string nameOfFindable;

    [SerializeField]
    public Mesh mesh;

    public float value;

    public string customTag = "Findable";

    public bool found = false;
}
