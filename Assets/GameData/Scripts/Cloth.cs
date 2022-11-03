using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    
    [CreateAssetMenu(fileName = "Cloth", menuName = "Item/Cloth", order = 0)]
    public class Cloth : ScriptableObject {
        public string name;
        public string description;
        public Sprite icon;

        public Animation[] animations;
    }

}
