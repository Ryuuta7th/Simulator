using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //======ITEM DATA======//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    [SerializeField] private int maxNumberOfItems;


    //====ITEM SLOT====//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private inventoryManager inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<inventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public int AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        //Slot Check Full/Empty
        if (this.quantity > 0 && this.itemName != itemName)
            return quantity;

        if (isFull)
            return quantity;

        if (this.quantity == 0)
        {
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            itemImage.sprite = itemSprite;
        }

        this.quantity += quantity;
        
        //Update Quantity       
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        
            //Return Leftovers
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update Quantity Text 
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button== PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button== PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

public void OnRightClick()
    {
        inventoryManager.DropItem(this);
    }

public void ClearSlot()
    {
        itemName = "";
        quantity = 0;
        itemSprite = null;
        isFull = false;

        itemImage.sprite = null;
        quantityText.enabled = false;
        selectedShader.SetActive(false);
        thisItemSelected = false;
    }

public void UpdateUI()
    {
        quantityText.text = quantity.ToString();
    }
}
