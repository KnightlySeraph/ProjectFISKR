using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent (typeof (CharacterController))]
public partial class PlayerControllerA : MonoBehaviour {
    public enum MoveDirection { Forward, Run, Reverse, Up, Stop }

    [SerializeField] private float topForwardSpeed = 6.0f;
    [SerializeField] private float maxJumpHeight = 1.0f;
    [SerializeField] private float acceleration = 5.0f;
    [SerializeField] private float deceleration = 10.0f;
    [SerializeField] private float gravity = 10.0f; //Needed for jumping later on
    [SerializeField] private float turnRate = 2.0f;

    private float currentSpeed;
    private float currentTopSpeed;
    private MoveDirection currentDirection = MoveDirection.Stop;
    private bool isAccelerating = false;
    private CharacterController player;
    private Transform playerTransform;
    private TrailRenderer playerSprintTrail;

    private void Awake () {
        player = GetComponent<CharacterController> ();
        playerTransform = GetComponent<Transform> ();
        playerSprintTrail = GetComponent<TrailRenderer>();
        currentTopSpeed = topForwardSpeed;
    }

    private void FixedUpdate () {
        // Direction to move this update.
        Vector3 playerDirection = Vector3.zero;
        // Direction requested this update.
        MoveDirection requestedDirection = MoveDirection.Stop;

        if (player.isGrounded) {
            float currentTurnRate = Mathf.Lerp (turnRate / 2, turnRate, 1 - (currentSpeed / currentTopSpeed));
            Vector3 angles = playerTransform.eulerAngles;
            angles.y += (Input.GetAxis ("Horizontal") * currentTurnRate);
            playerTransform.eulerAngles = angles;

            if (Input.GetAxis ("Vertical") > 0) { //Forward
                if (Input.GetKey (KeyCode.LeftShift)) {
                    requestedDirection = MoveDirection.Run;
                } else {
                    requestedDirection = MoveDirection.Forward;
                }
                isAccelerating = true;
            } else if (Input.GetAxis ("Vertical") < 0) { //Reverse
                requestedDirection = MoveDirection.Reverse;
                isAccelerating = true;
            } else { //No move, or can't move
                requestedDirection = currentDirection;

                isAccelerating = false;
            }
        }

        if (currentDirection == MoveDirection.Stop) {
            // Make sure we can go in the requested direction.
            if (((requestedDirection == MoveDirection.Reverse) && ((topForwardSpeed / 2) / 2 > 0)) ||
                ((requestedDirection == MoveDirection.Forward) && (topForwardSpeed / 2 > 0)) ||
                ((requestedDirection == MoveDirection.Run) && (topForwardSpeed > 0))) {
                currentDirection = requestedDirection;
            } //End direction based if statement
        } else {
            // Requesting a change of direction, but not stopped so we are braking.
            if (currentDirection != requestedDirection) {
                isAccelerating = false;
            }
        }
         playerSprintTrail.emitting = false;
        // Setup top speeds and move direction based off our enum
        if (currentDirection == MoveDirection.Forward) {
            
            playerDirection = Vector3.forward;
            currentTopSpeed = topForwardSpeed / 2; //Half of our run speed
        } else if (currentDirection == MoveDirection.Run) {
            playerSprintTrail.emitting = true;
            playerDirection = Vector3.forward;
            currentTopSpeed = topForwardSpeed; //Our top speed
        } else if (currentDirection == MoveDirection.Reverse) {
            playerDirection = -1 * Vector3.forward;
            currentTopSpeed = (topForwardSpeed / 2) / 2; //Half of half of the run speed
        } else if (currentDirection == MoveDirection.Stop) {
            playerDirection = Vector3.zero;
        }

        if (isAccelerating) { // If we haven't hit top speed, accelerate.
            if (currentSpeed < currentTopSpeed) {
                currentSpeed = currentSpeed + (acceleration * Time.deltaTime);
            }
        } else { //Not accelerating (Aka moving...)
            if (currentSpeed > 0) { //We decelerate IF greater than 0...else we would have reverse move
                currentSpeed = currentSpeed - (deceleration * Time.deltaTime / 2);
            }
        }

        // If our speed is below zero, stop and reset.
        if ((currentSpeed <= 0) && (currentDirection != MoveDirection.Stop)) {
            SetStopped ();
        } else {
            if (currentSpeed > currentTopSpeed) {
                currentSpeed = currentTopSpeed;
            }
        }

        if (player.isGrounded) {
            if (Input.GetAxis ("Jump") > 0) {
                playerDirection.z = maxJumpHeight;
                playerDirection.y = maxJumpHeight;
            }
        }
        playerDirection = playerTransform.TransformDirection (playerDirection);

        playerDirection.x = playerDirection.x * (currentSpeed * Time.deltaTime);
        playerDirection.y = playerDirection.y - (gravity * Time.deltaTime); // Implement gravity so we can stay grounded. Will change later for jumping
        playerDirection.z = playerDirection.z * (currentSpeed * Time.deltaTime);
        player.Move (playerDirection);

    }

    private void SetStopped () {
        currentSpeed = 0;
        currentDirection = MoveDirection.Stop;
        isAccelerating = false;
    }
}