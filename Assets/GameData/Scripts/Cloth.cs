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


        public Sprite MyIcon{
            get{
                return icon;
            }
        }


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
