using UnityEngine;
using System.Collections;

public class movementtrail : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector3 movementDirection = Vector3.right;

    public GameObject meteor;


   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        StartCoroutine(GetRidOf(20f));
    }

    private IEnumerator GetRidOf(float timer)
    {
        yield return new WaitForSeconds(timer);
        Object.Destroy(meteor);
    }
}
