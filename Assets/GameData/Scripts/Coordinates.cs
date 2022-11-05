using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    
    [CreateAssetMenu(fileName = "Coordinates", menuName = "Cloth-Game/Coordinates", order = 0)]
    public class Coordinates : ScriptableObject
    {
        public Vector2 coord;
    }
}

