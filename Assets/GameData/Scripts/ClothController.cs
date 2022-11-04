using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace clothgame{
  public class ClothController : MonoBehaviour
    {
       public Animator anim;
       public AnimatorOverrideController animatorOverrideController;
       public Image previewImage;

       public Cloth.ClothType clothType;

       public void SetAnimatorParameters(float x, float y){
           anim.SetFloat("horizontal", x);
           anim.SetFloat("vertical", y);
       }

       public void Use(Cloth cloth) {
        anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = animatorOverrideController;
        previewImage.sprite = cloth.icon;
        previewImage.color = new Color (1,1,1,1);

        animatorOverrideController["idle_down"] = cloth.animations[0];
        animatorOverrideController["idle_left"] = cloth.animations[1];
        animatorOverrideController["idle_right"] = cloth.animations[2];
        animatorOverrideController["idle_up"] = cloth.animations[3];
        animatorOverrideController["walk_down"] = cloth.animations[4];
        animatorOverrideController["walk_left"] = cloth.animations[5];
        animatorOverrideController["walk_right"] = cloth.animations[6];
        animatorOverrideController["walk_up"] = cloth.animations[7];
       } 
    }
}

