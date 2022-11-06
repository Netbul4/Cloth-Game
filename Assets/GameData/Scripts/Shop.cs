using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace clothgame{

    public class Shop : MonoBehaviour
    {
        public SlotScript[] slots;
        public TMP_Text[] prices;
        public Canvas shopCanvas;
        public Canvas sellCanvas;

        private void Start() {
            foreach(SlotScript slot in slots){  //Set the prices of each item.
                foreach(TMP_Text t in prices){
                    t.text = slot.price.ToString();
                }
            }
        }

        //Buy the Item and send it to the Inventory.
        public void BuyItem(Cloth cloth){
            if(PlayerController.money >= cloth.price){
                PlayerController.money -= cloth.price;
                Inventory.MyInstance.AddItem(cloth);
            }
        }

        //Open the Shop.
        public void Open(){
            shopCanvas.gameObject.SetActive(true);
        }

        //Close the Shop.
       public void Close(){
        shopCanvas.gameObject.SetActive(false);
       }
    }
}

