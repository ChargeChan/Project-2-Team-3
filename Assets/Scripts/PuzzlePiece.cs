using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int pieceID; // Unique ID for this puzzle piece
    public List<int> validNeighborIDs; // List of IDs this piece can connect to
}
