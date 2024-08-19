using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Speed of the bullet
    public float upwardAngle = 0; // Angle in degrees to move upward (positive value)

    private void Start()
    {
        // Calculate the initial forward direction with upward angle
        Vector3 forwardDirection = transform.forward;
        // Apply rotation around x-axis to tilt upward
        Vector3 upwardDirection = Quaternion.Euler(upwardAngle, 0, 0) * forwardDirection;
        // Set the bullet's velocity
        GetComponent<Rigidbody>().velocity = upwardDirection * speed;
    }

    private void Update()
    {
        // Optionally, if the bullet has no Rigidbody, move it manually
        // Uncomment the following lines if you are not using Rigidbody

        Vector3 forwardDirection = transform.forward;
         Vector3 upwardDirection = Quaternion.Euler(upwardAngle, 0, 0) * forwardDirection;
         transform.Translate(upwardDirection * speed * Time.deltaTime, Space.World);
    }
}
