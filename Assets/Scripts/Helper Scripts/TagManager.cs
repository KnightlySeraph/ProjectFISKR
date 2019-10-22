using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags {
    public const string MOVEMENT = "Movement";

    public const string COMBO_1_TRIGGER = "Combo1";
    public const string COMBO_2_TRIGGER = "Combo2";
    public const string COMBO_3_TRIGGER = "Combo3";

    public const string ATTACK_TRIGGER = "Attack";

    public const string IDLE_ANIMATION = "Idle";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";

    public class Axis {
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string VERTICAL_AXIS = "Vertical";
    }

    public class Tags {
        public const string GROUND_TAG = "Ground";
        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";

        public const string LEFT_ARM_TAG = "LeftArm";
        public const string LEFT_LEG_TAG = "LeftLeg";
        public const string UNTAGGED_TAG = "Untagged";
        public const string MAIN_CAMERA_TAG = "MainCamera";
        public const string HEALTH_UI_TAG = "HealthUI";
    }

}
