using UnityEngine;
using static UnityEngine.UI.Image;

public class ProbeScript : MonoBehaviour
{
    Ray findableCheck;
    Ray probeAttempt;
       
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

        if(Physics.Raycast(probeAttempt, out RaycastHit hitInfo))
        {
            Debug.Log("Probe Attempt");
        }
    }

    private void checkForFindable()
    {
        findableCheck = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(findableCheck, out RaycastHit hitInfo))
        {

            if (hitInfo.collider.CompareTag("Findable"))
            {
                Debug.Log("Findable Hit!");
            }

        }
    }
}
