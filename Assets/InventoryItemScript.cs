using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    Image myImage;
    private bool onCursor;
    void Start()
    {
        myImage = GetComponent<Image>();
        myImage.enabled = false;
        onCursor = false;
    }


    public void SetImage(string imageName)
    {
        Material mat = Resources.Load<Material>(imageName);
        myImage.material = mat;
        myImage.enabled = true;
        if(imageName == "null")
            myImage.enabled = false;
    }

    public void TestGameManager(int position)
    {
        //GameManager.Instance.SendMessage("RemoveItemFromInventory", position);
    }

    public void ClickItem()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log(objectHit.ToString());
            // Do something with the object that was hit by the raycast.
        }

        if (!onCursor)
        {
            onCursor = true;
        }
        else
        {
            onCursor = false;
            transform.position = gameObject.transform.parent.position;
        }
    }

    public void Update()
    {
        if(onCursor)
        {
            transform.position = Input.mousePosition;
        }
    }
}
