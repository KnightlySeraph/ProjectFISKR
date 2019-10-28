using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject weapon_Attack_Point;
    
    void weapon_Attack_On () {              //Enables attack point on weapon as an animator trigger event
        weapon_Attack_Point.SetActive(true);
    }
    
    void weapon_Attack_Off () {         //Disables attack point on weapon as an animator trigger event
        if (weapon_Attack_Point.activeInHierarchy) {
            weapon_Attack_Point.SetActive (false);

        }
    }
}
