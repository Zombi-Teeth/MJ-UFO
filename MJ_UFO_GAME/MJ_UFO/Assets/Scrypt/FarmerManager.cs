using System.Collections.Generic;
using UnityEngine;

public class FarmerManager : MonoBehaviour
{
    public static FarmerManager Instance { get; private set; }

    private List<Farmer> farmersOnScreen = new List<Farmer>(); // List to track on-screen farmers

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterFarmer(Farmer farmer)
    {
        if (!farmersOnScreen.Contains(farmer))
        {
            farmersOnScreen.Add(farmer);
            Debug.Log("Farmer registered: " + farmer.name + ". Total on-screen farmers: " + farmersOnScreen.Count);
        }
        else
        {
            Debug.LogWarning("Farmer already registered: " + farmer.name);
        }
    }

    public void UnregisterFarmer(Farmer farmer)
    {
        if (farmersOnScreen.Contains(farmer))
        {
            farmersOnScreen.Remove(farmer);
            Debug.Log("Farmer unregistered: " + farmer.name + ". Total on-screen farmers: " + farmersOnScreen.Count);
        }
        else
        {
            Debug.LogWarning("Farmer not found in the list: " + farmer.name);
        }
    }

    public bool IsAnyFarmerOnScreen()
    {
        return farmersOnScreen.Count > 0;
    }
}
