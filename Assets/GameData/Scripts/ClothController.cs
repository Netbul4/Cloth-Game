using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
  public class ClothController : MonoBehaviour
    {
       public Animator anim;
       public AnimationClip[] animations;
       public AnimatorOverrideController animatorOverrideController;

       public void SetAnimatorParameters(float x, float y){
           anim.SetFloat("horizontal", x);
           anim.SetFloat("vertical", y);
       }

       public void Equip() {
        animatorOverrideController["idle_down"] = animations[0];
        animatorOverrideController["idle_left"] = animations[1];
        animatorOverrideController["idle_right"] = animations[2];
        animatorOverrideController["idle_up"] = animations[3];
        animatorOverrideController["walk_down"] = animations[4];
        animatorOverrideController["walk_left"] = animations[5];
        animatorOverrideController["walk_right"] = animations[6];
        animatorOverrideController["walk_up"] = animations[7];
       } 
    }
}

