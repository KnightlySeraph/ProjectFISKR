using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimationTags;
public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;

    private float rotation_X = -90f;
    private float rotation_Y = 180f;    

    private float rotation_Speed = 15f;

    private void Awake () {
        player_Anim = GetComponentInChildren<CharacterAnimation> ();
        myBody = GetComponent<Rigidbody> ();
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        RotatePlayer ();
        AnimatePlayerWalk ();
    }

    void FixedUpdate() {
        DetectMovement ();
    }

    void DetectMovement() {
        myBody.velocity = new Vector3 (
            Input.GetAxisRaw (Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw (Axis.VERTICAL_AXIS) * (-z_Speed));

    } // Movement

    void RotatePlayer() {      //Rotates player facing direction of movement
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0) {

            transform.rotation = Quaternion.Euler (0f, -Mathf.Abs (rotation_X), 0f);

        } else if(Input.GetAxisRaw (Axis.HORIZONTAL_AXIS) < 0) {

            transform.rotation = Quaternion.Euler (0f, Mathf.Abs (rotation_X), 0f);

        } else if(Input.GetAxisRaw(Axis.VERTICAL_AXIS) > 0) {

            transform.rotation = Quaternion.Euler (0f, -Mathf.Abs (rotation_Y), 0f);

        } else if (Input.GetAxisRaw (Axis.VERTICAL_AXIS) < 0) {

            transform.rotation = Quaternion.Euler (0f, Mathf.Abs (0f), 0f);

        }
    } // Rotation

    void AnimatePlayerWalk () { //animation for walk plays when player is moving

        if (Input.GetAxisRaw (Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw (Axis.VERTICAL_AXIS) != 0) {

            player_Anim.Walk (true);

        } else {

            player_Anim.Walk (false);

        }

    }
}
