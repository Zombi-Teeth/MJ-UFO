using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{
    // The Text component to display the timer
    public Text timerText;

    // The GameObject to activate when the timer reaches zero
    public GameObject targetGameObject;

    // The starting time for the countdown in seconds
    public float countdownTime = 10f;

    private float timeRemaining;

    void Start()
    {
        // Initialize the timer
        timeRemaining = countdownTime;
        UpdateTimerText();
    }

    void Update()
    {
        // Decrease the time remaining
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // Ensure the timer doesn't go below zero
            timeRemaining = 0;
            UpdateTimerText();

            // Activate the target GameObject
            if (targetGameObject != null)
            {
                targetGameObject.SetActive(true);
            }

            // Optionally, you can disable the timer if you don't want it to keep updating
            enabled = false;
        }
    }

    void UpdateTimerText()
    {
        // Format the remaining time as minutes:seconds and update the Text component
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
