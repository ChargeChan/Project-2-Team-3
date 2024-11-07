using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawTrigger : MonoBehaviour
{
    public Camera outsideJigsaw;
    public Camera jigsawCamera; // Assign Camera 21 here

    void Start()
    {
        // Ensure only the player camera is active at the start
        if (jigsawCamera != null)
        {
            jigsawCamera.gameObject.SetActive(false);
        }
        outsideJigsaw.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        // Check if the jigsawCamera and playerCamera references are set
        if (jigsawCamera != null && outsideJigsaw != null)
        {
            // Switch to the jigsaw camera (Camera 21)
            outsideJigsaw.gameObject.SetActive(false);
            jigsawCamera.gameObject.SetActive(true);
        }
    }
}
