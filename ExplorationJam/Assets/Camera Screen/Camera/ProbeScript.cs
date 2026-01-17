using UnityEngine;

public class ProbeScript : MonoBehaviour
{
    Ray findableCheck;
    Ray probeAttempt;
       
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        findableCheck = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProbeAttempt();
        }
    }


    private void ProbeAttempt()
    {
        Debug.Log("Probe Attempted");
        if(Physics.Raycast(probeAttempt, out RaycastHit hitInfo))
        {
            Debug.Log("Probe Hit: " + hitInfo.collider.name);
        }
    }
}
