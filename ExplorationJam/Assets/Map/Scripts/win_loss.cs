using UnityEngine;

public class win_loss : MonoBehaviour
{
    [SerializeField] string targetTag = "Satellite"; 
    [SerializeField] float endZ = -3f; 
    [SerializeField] float zoomSpeed = 2f; 
    
    private Transform camTrans;
    private GameObject camTarget;
    private float currentZ;
    private float startZ;
    
    void Start()
    {
        camTrans = Camera.main.transform;
        startZ = camTrans.position.z; // Capture the original Z position
        currentZ = startZ;
    }
    
    void LateUpdate()
    {
        if (resourceTracker.Instance != null && resourceTracker.Instance.getLoss())
        {   
            // Find the target dynamically each frame
            camTarget = GameObject.FindGameObjectWithTag(targetTag);
            
            if (camTarget != null)
            {
                // Smooth zoom in
                currentZ = Mathf.Lerp(currentZ, endZ, zoomSpeed * Time.deltaTime);
                
                Vector3 targetPosition = camTarget.transform.position;
                targetPosition = new Vector3(targetPosition.x, targetPosition.y, currentZ);
                camTrans.position = targetPosition;
            }
            else
            {
                Debug.LogError("Could not find object with tag: " + targetTag);
            }
        }
    }
}