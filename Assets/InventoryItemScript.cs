using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    Image myImage;
    void Start()
    {
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImage(string imageName)
    {
        Material mat = Resources.Load<Material>(imageName);
        myImage.material = mat;
    }

    private void OnMouseDown()
    {
        Debug.Log("test");
    }
}
