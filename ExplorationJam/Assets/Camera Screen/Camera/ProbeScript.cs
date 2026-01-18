using UnityEngine;
using static UnityEngine.UI.Image;

public class ProbeScript : MonoBehaviour
{
    Ray findableCheck;
    Ray probeAttempt;

    public int ScoreFromPicture;

    public float probeRadius;
    public Transitions transitions;
       
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
    }


    private void ProbeAttempt()
    {
        findableCheck = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(findableCheck, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.gameObject.TryGetComponent<FindableID>(out FindableID findable))
            {
                ScoreFromPicture = findable.findableID;
            }
            else
            {
                ScoreFromPicture = 0;
            }


            if (hitInfo.collider.CompareTag("Findable"))
            {
                Debug.Log("Picture Taken");
                Debug.Log("Score From Picture: " + ScoreFromPicture);
                Debug.Log("Findable ID: " + findable.findableID);
                transitions.ToMapAfterPicture(ScoreFromPicture);

            }
        }
    }
}

