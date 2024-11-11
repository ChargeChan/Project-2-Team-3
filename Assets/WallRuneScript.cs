using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRuneScript : MonoBehaviour
{
    public Material materialOff;
    public Material materialOn;
    private Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        myRenderer.material = materialOn;
    }

    public void TurnOff()
    {
        myRenderer.material = materialOff;
    }

    IEnumerator FlipOn()
    {
        yield return new WaitForSeconds(4);
        myRenderer.material = materialOn;
        yield return new WaitForSeconds(1);
        myRenderer.material = materialOff;
    }
}
