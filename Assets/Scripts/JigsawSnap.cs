using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawSnap : MonoBehaviour
{
    // The snap distance to consider pieces connected when close enough
    public float snapDistance = 0.05f;

    private void OnTriggerEnter(Collider other)
    {
        // Only check for snapping if both colliders are tagged as "Jigsaw"
        if (other.CompareTag("Jigsaw"))
        {
            // Get the PuzzlePiece components for both pieces
            PuzzlePiece pieceData = GetComponent<PuzzlePiece>();
            PuzzlePiece otherPieceData = other.GetComponent<PuzzlePiece>();

            // Make sure both pieces have valid PuzzlePiece components attached
            if (pieceData != null && otherPieceData != null)
            {
                // Check if the pieces are compatible to snap (using their valid neighbor IDs)
                if (CanSnap(pieceData, otherPieceData))
                {
                    SnapPieces(other.gameObject);
                }
            }
        }
    }

    // Check if the two puzzle pieces can connect based on their IDs
    private bool CanSnap(PuzzlePiece piece1, PuzzlePiece piece2)
    {
        // Ensure that each piece has the valid neighbor IDs set up
        if (piece1.validNeighborIDs == null || piece2.validNeighborIDs == null)
        {
            Debug.LogError("validNeighborIDs list not assigned properly.");
            return false;
        }

        // Check if each piece’s valid neighbor list contains the other piece's ID
        bool canConnect = piece1.validNeighborIDs.Contains(piece2.pieceID) &&
                          piece2.validNeighborIDs.Contains(piece1.pieceID);

        // Debugging information
        Debug.Log($"Can {piece1.gameObject.name} connect to {piece2.gameObject.name}: {canConnect}");
        return canConnect;
    }

    // This function handles the actual snapping of two pieces together
    private void SnapPieces(GameObject otherPiece)
    {
        // Snap this piece to the other piece's position
        transform.position = otherPiece.transform.position;

        // Parent this piece to the other piece so they stay together
        transform.SetParent(otherPiece.transform);

        // Disable this piece's collider (so it won't trigger again)
        Collider myCollider = GetComponent<Collider>();
        if (myCollider != null)
        {
            myCollider.enabled = false;
        }

        // Optionally, disable the collider of the other piece as well to avoid future collisions
        Collider otherCollider = otherPiece.GetComponent<Collider>();
        if (otherCollider != null)
        {
            otherCollider.enabled = false;
        }

        Debug.Log($"{gameObject.name} snapped to {otherPiece.name}");
    }
}
