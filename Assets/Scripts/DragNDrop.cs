using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour
{
    public Camera puzzleCamera;
    public Camera backCamera;
    public GameObject selectPiece;
    public GameObject exitButton;
    public BoxCollider jigsawCollider;
    public GameObject camManagerUI;

    void Start()
    {
        if (puzzleCamera == null)
        {
            puzzleCamera = GameObject.Find("Cam21").GetComponent<Camera>();
            Debug.Log("Puzzle Camera assigned.");
        }

        if (backCamera == null)
        {
            backCamera = GameObject.Find("Cam13").GetComponent<Camera>();
            Debug.Log("Back Camera assigned.");
        }

        if (jigsawCollider == null)
        {
            jigsawCollider = GetComponent<BoxCollider>();
            Debug.Log("Jigsaw Collider assigned.");
        }

        if (exitButton != null)
        {
            exitButton.SetActive(false);
            exitButton.GetComponent<Button>().onClick.AddListener(ExitPuzzleView);
            Debug.Log("Exit button setup completed.");
        }
    }

    void Update()
    {
        if (puzzleCamera.gameObject.activeSelf)
        {
            Debug.Log("Puzzle Camera active. Handling interaction.");
            HandlePuzzleInteraction();
            EnterPuzzleView();
        }
    }

    private void HandlePuzzleInteraction()
    {
        // Use layer mask to raycast only for puzzle pieces
        int puzzleLayer = LayerMask.NameToLayer("PuzzleLayer"); // Replace with your layer name if needed
        int layerMask = 1 << puzzleLayer;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = puzzleCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.transform != null && hit.transform.CompareTag("Jigsaw"))
            {
                selectPiece = hit.transform.gameObject;
                Debug.Log("Selected piece: " + selectPiece.name);
            }
            else
            {
                Debug.Log("Raycast missed: No Jigsaw piece hit.");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectPiece = null;
            Debug.Log("Deselected piece.");
        }

        if (selectPiece != null)
        {
            Vector3 MousePoint = puzzleCamera.ScreenToWorldPoint(Input.mousePosition);
            selectPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }

    public void EnterPuzzleView()
    {
        Debug.Log("Entering puzzle view...");

        backCamera.gameObject.SetActive(false);
        puzzleCamera.gameObject.SetActive(true);

        if (jigsawCollider != null)
        {
            jigsawCollider.enabled = false;
            Debug.Log("Collider disabled.");
        }

        if (camManagerUI != null)
        {
            camManagerUI.SetActive(false);
            Debug.Log("Cam Manager UI disabled.");
        }

        if (exitButton != null)
        {
            exitButton.SetActive(true);
            Debug.Log("Exit button enabled.");
        }
    }

    private void ExitPuzzleView()
    {
        Debug.Log("Exiting puzzle view...");

        puzzleCamera.gameObject.SetActive(false);
        backCamera.gameObject.SetActive(true);

        if (jigsawCollider != null)
        {
            jigsawCollider.enabled = true;
            Debug.Log("Collider enabled.");
        }

        if (camManagerUI != null)
        {
            camManagerUI.SetActive(true);
            Debug.Log("Cam Manager UI enabled.");
        }

        if (exitButton != null)
        {
            exitButton.SetActive(false);
            Debug.Log("Exit button disabled.");
        }
    }
}
