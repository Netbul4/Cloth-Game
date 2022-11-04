using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    public class Inventory : MonoBehaviour
   {
       public static Inventory instance;

       public List<SlotScript> slots = new List<SlotScript>();
       public Canvas invCanvas;
       public Cloth cl;

       private void Update() {
         if(Input.GetKeyDown(KeyCode.I)) invCanvas.gameObject.SetActive(true);
         if(Input.GetKeyDown(KeyCode.K)) AddItem(cl);
       }

       public void Close(){
        invCanvas.gameObject.SetActive(false);
       }

       public bool AddItem(Cloth cloth){
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
