using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSpotlight : MonoBehaviour
{
    public Light spotlight;
    public Rigidbody playerRb;
    private bool wasMovingLastFrame = false;

    void Start()
    {
        if (spotlight == null)
        {
            spotlight = GetComponent<Light>();
        }

        if (playerRb == null)
        {
            Debug.LogError("Player Rigidbody not assigned.");
        }
    }

    void Update()
    {
        bool isMovingThisFrame = playerRb.velocity.magnitude > 0.1f;

        if (isMovingThisFrame && !wasMovingLastFrame)
        {
            spotlight.enabled = false;
        }
        else if (!isMovingThisFrame && wasMovingLastFrame)
        {
            spotlight.enabled = true;
        }

        wasMovingLastFrame = isMovingThisFrame;
    }
}
