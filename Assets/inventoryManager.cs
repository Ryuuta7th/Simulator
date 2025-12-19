using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Collider2D playerCollider;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && menuActivated )
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetKeyDown(KeyCode.B) && !menuActivated )
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }

    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite)
{
    // 1️⃣ CARI ITEM YANG SAMA (STACKING)
    for (int i = 0; i < itemSlot.Length; i++)
    {
        if (!itemSlot[i].isFull &&
            itemSlot[i].quantity > 0 &&
            itemSlot[i].itemName == itemName)
        {
            int leftOver = itemSlot[i].AddItem(itemName, quantity, itemSprite);

            if (leftOver > 0)
                return AddItem(itemName, leftOver, itemSprite);

            return 0;
        }
    }

    // 2️⃣ BARU CARI SLOT KOSONG
    for (int i = 0; i < itemSlot.Length; i++)
    {
        if (itemSlot[i].quantity == 0 && string.IsNullOrEmpty(itemSlot[i].itemName))
        {
            itemSlot[i].AddItem(itemName, quantity, itemSprite);
            return 0;
        }
    }

    // 3️⃣ INVENTORY PENUH
    return quantity;
}
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void DropItem (ItemSlot slot)
    {
        Debug.Log("DROP ITEM DIPANGGIL");
        
        if (slot.quantity <= 0)
            return;

        Debug.Log("itemPrefab: " + itemPrefab);
        Debug.Log("playerTransform: " + playerTransform);
        Debug.Log("playerCollider: " + playerCollider);
        
        float radius = playerCollider.bounds.extents.y;
        Vector3 dropPos = 
            playerTransform.position + 
            playerTransform.up * (radius + 0.1f);

        GameObject droppedItem = Instantiate(itemPrefab, dropPos, Quaternion.identity);

        Item item = droppedItem.GetComponent<Item>();
        if (item == null)
        {
            Debug.LogError("Prefab tidak punya script Item!");
            return;
        }

        item.SetItem(slot.itemName, 1, slot.itemSprite);

        slot.quantity--;

        if (slot.quantity <= 0)
            slot.ClearSlot();
        else
            slot.UpdateUI();

    }

    private void Awake()
    {
        if (playerTransform == null)
        {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerCollider = player.GetComponent<Collider2D>();
        }
    }

}
