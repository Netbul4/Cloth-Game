using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    public class Inventory : MonoBehaviour
   {
        static Inventory instance;

        public static Inventory MyInstance{
            get{
                if(instance == null){
                    instance = FindObjectOfType<Inventory>();
                }

                return instance;
            }
        }

       public List<SlotScript> slots = new List<SlotScript>();
       public Canvas invCanvas;
       public Cloth cl;

       private void Update() {
         if(Input.GetKeyDown(KeyCode.I)) invCanvas.gameObject.SetActive(true);
       }

       public void Close(){
        invCanvas.gameObject.SetActive(false);
       }

       public bool AddItemToInv(Cloth cloth){
        foreach (SlotScript slot in slots)
        {
            if(slot.IsEmpty){
                slot.AddItem(cloth);

                return true;
            }
        }
        return false;
       }
   }

}
