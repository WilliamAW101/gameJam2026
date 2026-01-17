using UnityEngine;
public class SatelliteControl : MonoBehaviour
{
    [SerializeField] float thrustForce;
    private Rigidbody satelliteThruster;
    void Start()
    {
        satelliteThruster = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rotateSatellite();

        if (Input.GetKey(KeyCode.W))
        {
            thrustForward(thrustForce);
        }
    }

    public void rotateSatellite()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90f);
    }

    public void thrustForward(float thrustForce)
    {
        satelliteThruster.AddForce(transform.up * thrustForce);
    }
}