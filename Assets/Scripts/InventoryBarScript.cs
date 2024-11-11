using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBarScript : MonoBehaviour
{
    public GameObject[] slots = new GameObject[5];
    public GameObject panfluteToggle;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SendMessage("wake up", SendMessageOptions.DontRequireReceiver);
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

    public void EnablePanFlute()
    {
        panfluteToggle.SetActive(true);
    }
}
