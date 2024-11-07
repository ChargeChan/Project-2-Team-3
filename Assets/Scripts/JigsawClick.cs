using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawClick : MonoBehaviour
{
    private CamManager camManager;  // Reference to your Camera Manager
    private bool isInJigsawMode = false;  // Flag to check if in the jigsaw camera mode

    private GameObject selectedPiece;  // The puzzle piece currently being dragged
    private Vector3 offset;  // The offset between the mouse position and the piece's position
    private Camera puzzleCamera;  // The camera used to view the jigsaw puzzle
    public LayerMask puzzleLayer;  // Make sure this is set in the inspector to include layer 6

    void Start()
    {
        camManager = FindObjectOfType<CamManager>();  // Ensure CamManager is set up in the scene
        Debug.Log("CamManager found: " + (camManager != null));
    }

    void Update()
    {
        // Only proceed if in jigsaw mode
        if (isInJigsawMode)
        {
            // Left mouse button pressed
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = GetRaycastHit();  // Perform raycast to detect clicked piece

                if (hit.collider != null && hit.collider.CompareTag("Jigsaw"))
                {
                    selectedPiece = hit.transform.gameObject;  // Set selected piece
                    offset = selectedPiece.transform.position - (Vector3)hit.point;  // Convert Vector2 hit.point to Vector3
                    Debug.Log("Selected piece: " + selectedPiece.name);
                }
                else
                {
                    Debug.Log("Raycast missed: No Jigsaw piece hit.");
                }
            }

            // If dragging a piece, move it with the mouse
            if (selectedPiece != null)
            {
                Vector3 mousePosition = puzzleCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;  // Ensure the piece stays on the same plane

                selectedPiece.transform.position = mousePosition + offset;
            }

            // Left mouse button released
            if (Input.GetMouseButtonUp(0))
            {
                if (selectedPiece != null)
                {
                    Debug.Log("Deselected piece: " + selectedPiece.name);
                }
                selectedPiece = null;  // Deselect piece
            }
        }
    }

    // Perform raycast to detect if a puzzle piece is clicked
    private RaycastHit2D GetRaycastHit()
    {
        // Convert the mouse position to world space and cast a ray using the jigsaw camera
        Vector2 mousePosition = puzzleCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, puzzleLayer);  // Cast ray to detect colliders with specific layer mask

        // Debugging the raycast
        Debug.DrawRay(mousePosition, Vector2.zero, Color.red, 1f);  // Draws a red ray in the scene view
        Debug.Log("Raycast from position: " + mousePosition + " hit: " + hit.collider?.name);

        return hit;
    }

    // On mouse click, switch to jigsaw mode if not already in it
    void OnMouseDown()
    {
        if (!isInJigsawMode && camManager != null)
        {
            // Switch to the jigsaw camera (Cam21)
            camManager.SetActiveCamera(21);  // Switch to the jigsaw camera
            isInJigsawMode = true;  // Set the flag to true
            puzzleCamera = camManager.GetCamera(21);  // Directly assign the puzzle camera (Cam21)
            Debug.Log("Switched to jigsaw camera.");
        }
    }
}

