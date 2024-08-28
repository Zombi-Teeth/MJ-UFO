using System.Collections;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile to shoot
    public GameObject target; // The UFO target
    public Transform onScreenPoint; // Reference to the on-screen point
    public Transform offScreenPoint; // Reference to the off-screen point
    public float moveSpeed = 2.0f; // Speed at which the farmer moves

    private bool isOnScreen = false; // Track whether the farmer is currently on-screen
    private Camera mainCamera;
    private bool isActive = true; // Flag to indicate if the farmer is active

    private void Start()
    {
        if (FarmerManager.Instance == null)
        {
            Debug.LogError("FarmerManager instance not found!");
            return;
        }

        target = GameObject.Find("UFO_Color1");
        if (target == null)
        {
            Debug.LogError("Player object not found!");
            return;
        }

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        transform.position = offScreenPoint.position; // Start off-screen
        StartCoroutine(HandleFarmer());
    }

    private void Update()
    {
        if (!isActive || mainCamera == null) return;

        // Check if the farmer is on screen
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        isOnScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    private IEnumerator HandleFarmer()
    {
        while (true)
        {
            // Wait until no other farmer is on-screen
            while (FarmerManager.Instance.IsAnyFarmerOnScreen())
            {
                yield return null;
            }

            // Move farmer onto the screen
            yield return StartCoroutine(MoveFarmer(onScreenPoint.position));

            // Register this farmer
            FarmerManager.Instance.RegisterFarmer(this);

            // Wait until the farmer is fully on-screen
            yield return new WaitUntil(() => isOnScreen);

            // Start shooting at random intervals
            yield return StartCoroutine(ShootAtRandomIntervals());

            // Move farmer off the screen
            yield return StartCoroutine(MoveFarmer(offScreenPoint.position));

            // Unregister this farmer
            FarmerManager.Instance.UnregisterFarmer(this);

            // Wait for a random time before the next farmer comes on-screen
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
    }

    private IEnumerator MoveFarmer(Vector3 targetPosition)
    {
        // Slide in or out
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        // Ensure the farmer is correctly registered as on-screen
        if (targetPosition == onScreenPoint.position)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
            isOnScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }
    }

    private IEnumerator ShootAtRandomIntervals()
    {
        float shootDuration = 5.0f; // Time farmer stays on-screen and shoots
        float elapsedTime = 0.0f;

        while (elapsedTime < shootDuration)
        {
            // Generate a random interval before the next shot
            float randomInterval = Random.Range(1.0f, 3.0f); // Adjust range as necessary

            // Wait for the random interval
            yield return new WaitForSeconds(randomInterval);

            // Shoot at the UFO
            Shoot();

            elapsedTime += randomInterval; // Add the interval time to the elapsed time
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || target == null) return;

        // Instantiate the projectile at the farmer's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the UFO
        Vector3 direction = (target.transform.position - transform.position).normalized;

        // Rotate the projectile to face the target direction
        projectile.transform.rotation = Quaternion.LookRotation(direction);

        // Apply velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * 20.0f; // Adjust speed as necessary
        }
        else
        {
            Debug.LogError("Projectile Rigidbody component not found!");
        }
    }
}
