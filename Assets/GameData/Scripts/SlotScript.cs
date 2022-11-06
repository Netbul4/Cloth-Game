using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clothgame{
    public class SlotScript : MonoBehaviour
    {
        public Cloth thisCloth;   //The actual cloth of this slot.
        public GameObject actions;  //Actions UI.

        public int price;

        [SerializeField]
        Image icon;

        //Check if the slot is Empty or not.
        public bool IsEmpty{
            get{
                return thisCloth == null;
            }
        }

        //Launch the Actions.
        public void LaunchActions(){
            actions.SetActive(true);
        }

        //Set the new Item on the Slot.
        public bool AddItem(Cloth cloth){
            icon.sprite = cloth.MyIcon;
            thisCloth = cloth;
            icon.color = new Color(1,1,1,1f);
            return true;
        }

        //Remove the Item of the Slot.
        public bool RemoveItem(Cloth cloth){
            if(!IsEmpty){
                thisCloth = cloth;
                cloth = null;
                icon.color = new Color(0,0,0,0);
                return true;
            }
            return false;
        }

        //Send the cloth to the ClothController, and uses it.
        public void UseCloth(){
            if(!IsEmpty){
                actions.SetActive(false);
                ClothController[] myCloth = FindObjectsOfType<ClothController>();
                foreach(ClothController c in myCloth){ 
                    if(thisCloth != null){
                        if(thisCloth.clothType == c.clothType){     //Check if the type of the Cloth is the same. (Shirt or Pants in this case).
                    c.animatorOverrideController = thisCloth.overrideController;
                    c.Use(thisCloth);
                    RemoveItem(thisCloth);
                }
                }
                    
            }  
        }
    }

    //Sell the cloth of this slot.
        public void SellCloth(){
            if(!IsEmpty){
                actions.SetActive(false);
                PlayerController.money = PlayerController.money + thisCloth.price;
                RemoveItem(thisCloth);
            }
        }
}
}

