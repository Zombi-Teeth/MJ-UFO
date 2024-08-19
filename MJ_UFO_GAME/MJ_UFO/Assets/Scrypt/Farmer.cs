using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject objectToInstantiate; // The GameObject to instantiate
    public float interval = 2.0f; // Time in seconds between each instantiation

    private void Start()
    {
        // Start the coroutine to instantiate objects at regular intervals
        StartCoroutine(InstantiateObjects());
    }

    private IEnumerator InstantiateObjects()
    {
        while (true) // Infinite loop to keep instantiating objects
        {
            // Instantiate the object at the current position and with no rotation
            Instantiate(objectToInstantiate, transform.position, this.transform.rotation);

            // Wait for the specified interval before continuing
            yield return new WaitForSeconds(interval);
        }
    }
}
