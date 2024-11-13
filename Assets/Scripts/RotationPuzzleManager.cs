using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPuzzleManager : MonoBehaviour
{
    public RotationPuzzle[] squares; // References to each square
    public Animator puzzleCompleteAnimator; // Animator for the win animation
    private bool puzzleComplete = false;

    private void Start()
    {
        ScrambleRotations();
    }

    private void Update()
    {
        if (puzzleComplete) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                RotationPuzzle square = hit.collider.GetComponent<RotationPuzzle>();
                if (square != null)
                {
                    square.RotateSquare();
                    CheckPuzzleCompletion();
                }
            }
        }
    }

    private void CheckPuzzleCompletion()
    {
        // Check if all squares are correctly aligned
        foreach (RotationPuzzle square in squares)
        {
            if (!square.IsCorrectlyAligned())
            {
                return; // If any square is misaligned, exit early
            }
        }

        // If all squares are correctly aligned, trigger win condition
        puzzleComplete = true;
        puzzleCompleteAnimator.SetTrigger("PuzzleComplete");
        LockSquares();
    }

    private void LockSquares()
    {
        foreach (RotationPuzzle square in squares)
        {
            square.LockRotation();
        }
    }

    public void ScrambleRotations()
    {
        foreach (RotationPuzzle square in squares)
        {
            // Generate a random number (0, 1, 2, or 3) and multiply by 90 for a random 90-degree increment
            int randomAngle = Random.Range(0, 4) * 90;
            Quaternion randomRotation = Quaternion.Euler(randomAngle, 0, 0); // X-axis rotation only

            // Apply this random rotation as the starting rotation of the square
            square.transform.rotation = randomRotation;
        }
    }
}
