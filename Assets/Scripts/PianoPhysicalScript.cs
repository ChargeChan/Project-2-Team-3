using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPhysicalScript : MonoBehaviour
{
    public Canvas pianoOverlay;
    // Start is called before the first frame update
    
    private void OnMouseDown()
    {
        pianoOverlay.enabled = true;
    }
}
