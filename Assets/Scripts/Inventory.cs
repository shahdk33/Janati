using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //variables
    public GameObject inventoryPanel;
    public GameObject shopPanel;

    //slots list 
    public List<Slot> slots = new List<Slot>();
    public bool isShopOpen = true;


    void Update(){
        //opening and closing menu
        if (Input.GetKeyDown(KeyCode.Tab)){
            //if player pressed button, toggle inventory for opening and closing
            ToggleInventory();
        }

    }

    public void ToggleInventory(){
        if(!inventoryPanel.activeSelf){
            //if inventoryPanel off, then turn on
            inventoryPanel.SetActive(true);
            shopPanel.SetActive(false);
            isShopOpen = true;

            // Setup();
        }
        else{
            inventoryPanel.SetActive(false);
            isShopOpen = false;
        }
    }

    public void ToggleShop(){
        if(!shopPanel.activeSelf){
            shopPanel.SetActive(true);
            inventoryPanel.SetActive(false);
            isShopOpen = false;
        }
        else{
            shopPanel.SetActive(false);
            inventoryPanel.SetActive(true);
            isShopOpen = true;

        }
    }

    //planting from an inventory slot
    public void Seed(){

        //todo: Go through Slot List

        //in Gold, when we buy a icon, save as variable icon 

    }

    public void AcquirePlant(){
        //after they buy it, we should know which plant they have
        //know the icon 
    
    }


}