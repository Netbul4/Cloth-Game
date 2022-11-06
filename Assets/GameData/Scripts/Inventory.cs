using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace clothgame{
    public class Inventory : MonoBehaviour
   {
        static Inventory instance;
        public List<SlotScript> slots = new List<SlotScript>();
        public Canvas invCanvas;
        public TMP_Text moneyText;

        //Here we get a public instance of the Inventory.
        public static Inventory MyInstance{  
            get{
                if(instance == null){
                    instance = FindObjectOfType<Inventory>();
                    DontDestroyOnLoad(instance.gameObject);
                }

                return instance;
            }
        }

        private void Awake() {
            if(instance != null){
                Destroy(gameObject);
            }else{
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

       

       private void Update() {
         if(Input.GetKeyDown(KeyCode.I)) invCanvas.gameObject.SetActive(true);
         moneyText.text = "Currency: $" + PlayerController.money.ToString(); //Set the currency of the player.
       }

       //Close the Inventory.
       public void Close(){
        invCanvas.gameObject.SetActive(false);
       }

       //Add a Cloth on the Slot selected.
       public bool AddItem(Cloth cloth){
        foreach (SlotScript slot in slots)
        {
            if(slot.IsEmpty){  //Choose the first empty Slot.
                slot.AddItem(cloth);

                return true;
            }
        }
        return false;
       }
   }

}
