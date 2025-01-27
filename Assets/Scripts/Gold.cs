using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{

    public int gold;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI price; 
    public int priceInt;

    //icons to place on screen
    public int remainingIcons;


    //gets the coins from game manager
    public void Start(){
        gold = GameDataManager.Gold;
        remainingIcons = 0;

    }

    //On run, show their ammount of money
    public void Update(){
        goldText.text = gold + "$";
    }

    public void Buy(){
        priceInt = 0;
        //when they buy an item from store, subtract the price from their ammount of gold
        //onclick of a slot

        //changing the price textmeshpro to text, then parse to int
        int.TryParse(price.text, out priceInt);

        //subtract price from the gold we have IF enough money
        if(gold-priceInt>=0){
            gold = gold - priceInt;
            goldText.text = gold + "$";
            remainingIcons++;

        }else{
            Debug.Log("NOT ENOUGH MONEY!");
        }


    }




}