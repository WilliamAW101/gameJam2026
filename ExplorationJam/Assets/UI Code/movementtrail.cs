using UnityEngine;

public class movementtrail : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector3 movementDirection = Vector3.right;

    public GameObject meteor;


   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Object.Destroy(meteor);
    }
}
