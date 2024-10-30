using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPhysicalScript : MonoBehaviour
{
    public Canvas pianoOverlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        pianoOverlay.enabled = true;
    }
}
