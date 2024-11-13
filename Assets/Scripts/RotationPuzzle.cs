using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzle : MonoBehaviour
{
    private Quaternion targetRotation;
    public Quaternion correctRotation; // Set this to the final orientation for each square
    private bool locked = false;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    public void RotateSquare()
    {
        if (locked) return;
        targetRotation *= Quaternion.Euler(90, 0, 0); // Rotate by 90 degrees
    }

    public bool IsCorrectlyAligned()
    {
        // Check if the square is close to its correct rotation
        return Quaternion.Angle(transform.rotation, correctRotation) < 1f;
    }

    public void LockRotation()
    {
        locked = true;
    }

    private void Update()
    {
        // Smooth rotation towards target rotation if not locked
        if (!locked)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }
}
