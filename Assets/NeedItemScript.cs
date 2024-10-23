using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedItemScript : MonoBehaviour
{
    public string itemNeeded;
    private bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GiveItem(string item)
    {
        if(item == itemNeeded)
        {
            locked = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
