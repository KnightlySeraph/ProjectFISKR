using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject weapon_Attack_Point;
    
    void weapon_Attack_On () {
        weapon_Attack_Point.SetActive(true);
    }
    
    void weapon_Attack_Off () {
        if (weapon_Attack_Point.activeInHierarchy) {
            weapon_Attack_Point.SetActive (false);

        }
    }
}
