using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float stayDuration = 3.0f; // Duration for which the cow stays in the beam before being destroyed

    private Dictionary<GameObject, float> cowsInBeam = new Dictionary<GameObject, float>();

    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            // Add the cow to the dictionary with the current time
            if (!cowsInBeam.ContainsKey(other.gameObject))
            {
                cowsInBeam.Add(other.gameObject, Time.time);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cow"))
        {
            // Remove the cow from the dictionary
            if (cowsInBeam.ContainsKey(other.gameObject))
            {
                player.gameObject.GetComponent<Player>().score += 20;
                cowsInBeam.Remove(other.gameObject);
            }
        }
    }

    private void Update()
    {
        // List to store cows that should be destroyed
        List<GameObject> cowsToDestroy = new List<GameObject>();

        foreach (var kvp in cowsInBeam)
        {
            GameObject cow = kvp.Key;
            float entryTime = kvp.Value;

            // Check if the cow should be destroyed
            if (Time.time - entryTime >= stayDuration)
            {
                cowsToDestroy.Add(cow);
            }
        }

        // Destroy cows that need to be destroyed
        foreach (GameObject cow in cowsToDestroy)
        {
            Destroy(cow);
            cowsInBeam.Remove(cow); // Remove from dictionary after destruction
        }
    }
}
