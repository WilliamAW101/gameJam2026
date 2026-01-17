using UnityEngine;
using static UnityEngine.UI.Image;

public class ProbeScript : MonoBehaviour
{
    Ray findableCheck;
    Ray probeAttempt;

    public float probeRadius;
       
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ProbeAttempt();
        }

        checkForFindable();
    }


    private void ProbeAttempt()
    {
        probeAttempt = new Ray(transform.position, transform.forward);

        if(Physics.SphereCast(probeAttempt, probeRadius, out RaycastHit hitInfo))
        {
            Debug.Log("Probe Attempt");

            if (hitInfo.collider.CompareTag("Findable"))
            {
                Debug.Log("Findable Hit!");
            }

        }
    }

    private void checkForFindable()
    {
        findableCheck = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(findableCheck, out RaycastHit hitInfo))
        {

            

        }
    }
}
