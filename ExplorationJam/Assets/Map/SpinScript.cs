using UnityEngine;

public class RandomSpinner : MonoBehaviour
{
    
    public float minSpeed = 10f;
    public float maxSpeed = 30f;

    private float currentSpinSpeed;
    private Vector3 rotationAxis = Vector3.up; 

    void Start()
    {

        float randomSpeed = Random.Range(minSpeed, maxSpeed);


        if (Random.value < 0.5f)
        {

            currentSpinSpeed = -randomSpeed;
        }
        else
        {

            currentSpinSpeed = randomSpeed;
        }


    }

    void Update()
    {
        transform.Rotate(rotationAxis, currentSpinSpeed * Time.deltaTime);
    }
}

