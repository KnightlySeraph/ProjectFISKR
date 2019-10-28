using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState {
    NONE,
    COMBO_1,
    COMBO_2,
    COMBO_3
}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 1.0f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    void Awake () {
        player_Anim = GetComponentInChildren<CharacterAnimation> ();

    }
    // Start is called before the first frame update
    private void Start ()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks ();
        ResetComboState ();
    }

    void ComboAttacks () {

        if (Input.GetKeyDown (KeyCode.Mouse0)) { //Input.GetKeyDown (KeyCode.Z)

            if (current_Combo_State == ComboState.COMBO_3)
                return;

            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.COMBO_1) {
                player_Anim.Combo_1 ();
            }

            if (current_Combo_State == ComboState.COMBO_2) {
                player_Anim.Combo_2 ();
            }
            if (current_Combo_State == ComboState.COMBO_3) {
                player_Anim.Combo_3 ();
            }

        }

        //if (Input.GetKeyDown (KeyCode.X)) {

        //}
    }

    void ResetComboState () {

        if (activateTimerToReset) {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f) {
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
