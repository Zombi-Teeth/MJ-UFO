using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float moveSpeed = 0.1f;           // Speed at which the object moves forward
    public float rotationAngle = 45f;       // The angle to rotate (left or right)
    public float rotationInterval = 5f;     // Interval in seconds between rotations

    private float nextRotationTime = 0f;    // Time when the next rotation should occur

    private void Update()
    {
        // Move the GameObject forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check if it's time to rotate
        if (Time.time >= nextRotationTime)
        {
            // Set the time for the next rotation
            nextRotationTime = Time.time + rotationInterval;

            // Determine random direction
            bool rotateRight = Random.value > 0.5f;

            // Rotate smoothly
            StartCoroutine(SmoothRotate(rotateRight ? rotationAngle : -rotationAngle));
        }
    }

    private IEnumerator SmoothRotate(float angle)
    {
        float elapsedTime = 0f;
        float duration = 1f; // Duration of the smooth rotation

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, angle, 0));

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
    }
}