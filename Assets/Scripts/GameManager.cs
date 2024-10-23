using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject inventoryBar;
    private static GameManager _instance;
    [SerializeField] private string[] inventory;
    

    private GameManager()
    {
        inventory = new string[5];
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();

                DontDestroyOnLoad(go);

                
            }

            return _instance;
        }
    }

    private void Awake()
    {
        inventoryBar = GameObject.Find("InventoryBar");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToIneventory(string item)
    {

        for(int i=0; i<inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                inventoryBar.SendMessage("SetInventory", inventory);
                return;
            }
        }
        Debug.Log("Inventory Full");
    }

    public void RemoveItemFromInventory(int position)
    {
        inventory[position] = null;
        inventoryBar.SendMessage("SetInventory", inventory);
    }
}
