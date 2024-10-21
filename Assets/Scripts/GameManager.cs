using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private List<string> inventory;

    private GameManager()
    {
        inventory = new List<string>();
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


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToIneventory(string item)
    {
        inventory.Add(item);
    }
}
