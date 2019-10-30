using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake () {
        anim = GetComponent<Animator> ();
    }

    public void Walk (bool move) {
        anim.SetBool (AnimationTags.MOVEMENT, move);
    }
    
    public void Dodge () {
        anim.SetTrigger (AnimationTags.DODGE_TRIGGER);
    }
    
    public void Combo_1 () {
        anim.SetTrigger (AnimationTags.COMBO_1_TRIGGER);
    }

    public void Combo_2 () {
        anim.SetTrigger (AnimationTags.COMBO_2_TRIGGER);
    }

    public void Combo_3 () {
        anim.SetTrigger (AnimationTags.COMBO_3_TRIGGER);
    }

    // ENEMY
    public void play_IdleAnimation () {
        anim.Play (AnimationTags.IDLE_ANIMATION);
    }
    public void Hit () {
        anim.SetTrigger (AnimationTags.HIT_TRIGGER);
    }

    public void EnemyAttack (int attack) {
        if (attack == 0) {
            anim.SetTrigger (AnimationTags.ATTACK_TRIGGER);
        }
    }
}
