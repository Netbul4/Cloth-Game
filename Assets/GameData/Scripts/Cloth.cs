using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    
    [CreateAssetMenu(fileName = "Cloth", menuName = "Item/Cloth", order = 0)]
    public class Cloth : ScriptableObject {

        public enum ClothType{shirt, pant};
        public ClothType clothType;

        public Sprite icon;
        public string name;
        public string description;
        public int price;
        private SlotScript slot;

        public AnimatorOverrideController overrideController;
        public AnimationClip[] animations;

        //To get the Icon in other classes.
        public Sprite MyIcon{
            get{
                return icon;
            }
        }


        //To get this Slot in other classes.
        protected SlotScript Slot{
            get{
                return slot;
            }

            set{
                slot = value;
            }
        }
    }

}
