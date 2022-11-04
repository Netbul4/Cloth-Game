using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace clothgame{

    public class Shop : MonoBehaviour
    {
        public SlotScript[] slots;
        public TMP_Text[] prices;
        public Canvas shopCanvas;

        private void Start() {
            foreach(SlotScript slot in slots){
                foreach(TMP_Text t in prices){
                    t.text = slot.price.ToString();
                }
            }
        }


        public void BuyItem(Cloth cloth){
            if(PlayerController.money >= cloth.price){
                PlayerController.money -= cloth.price;
                Inventory.MyInstance.AddItemToInv(cloth);
            }
        }

        public void Open(){
            shopCanvas.gameObject.SetActive(true);
        }

       public void Close(){
        shopCanvas.gameObject.SetActive(false);
       }
    }
}

