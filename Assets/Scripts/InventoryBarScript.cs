using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBarScript : MonoBehaviour
{
    public GameObject[] slots = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SendMessage("wake up", SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string name)
    {
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if(slots[i] == null)
        //    {
        //        slots[i].SendMessage("SetImage", name);
        //        Debug.Log("set image " + i);
        //        return;
        //    }
        //}
        //Debug.Log("inventory full");
    }

    public void SetInventory(string[] strings)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (strings[i] != null)
            {
                slots[i].SendMessage("SetImage", strings[i]);
            }
            if (strings[i] == null)
                slots[i].SendMessage("SetImage", "null");
        }
    }
}
