using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawCollider : MonoBehaviour
{
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void DisableCollider()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }

    public void EnableCollider()
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }
    
}
