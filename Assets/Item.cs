using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    [SerializeField] private int quantity;

    [SerializeField] private Sprite sprite;

    private inventoryManager inventoryManager;

    void Start ()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<inventoryManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            else 
                quantity = leftOverItems;
        }
    }

    public void SetItem (string name, int qty, Sprite spr)
    {
        itemName = name;
    }
}
