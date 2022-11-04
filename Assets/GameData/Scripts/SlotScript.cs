using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace clothgame{
    public class SlotScript : MonoBehaviour
    {
        public Cloth thisCloth;

        public int price;
        Button MyButton;

        [SerializeField]
        Image icon;

        public bool IsEmpty{
            get{
                return thisCloth == null;
            }
        }

        public bool AddItem(Cloth cloth){
            icon.sprite = cloth.MyIcon;
            thisCloth = cloth;
            icon.color = new Color(1,1,1,1f);
            return true;
        }

        public void RemoveItem(){
            if(!IsEmpty){
                thisCloth = null;
                icon.color = new Color(0,0,0,0);
            }
        }

        public void UseCloth(){
            if(!IsEmpty){
                ClothController[] myCloth = FindObjectsOfType<ClothController>();
                foreach(ClothController c in myCloth){
                    if(thisCloth.clothType == c.clothType){
                    c.animatorOverrideController = thisCloth.overrideController;
                    c.Use(thisCloth);
                    RemoveItem();
                }
            }
            
        }
    }
}
}

