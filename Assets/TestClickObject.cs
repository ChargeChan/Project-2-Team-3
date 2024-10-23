using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClickObject : MonoBehaviour
{
    public string myName;
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

    void OnMouseDown()
    {
        GameManager.Instance.AddItemToIneventory(myName);
        Destroy(gameObject);
    }

    

    private void OnMouseEnter()
    {
        //myRenderer.enabled = false;
        
    }

    private void OnMouseExit()
    {
        //myRenderer.enabled=true;
    }
}
