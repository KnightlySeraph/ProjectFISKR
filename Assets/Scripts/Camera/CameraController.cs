using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform player;
    private float xSpeed = 250.0f;
    private float ySpeed = 120.0f;
    private const float multiplier = 0.02f;
    private float yMin = -15f;
    private float yMax = 80f;
    private float x = 0f;
    private float y = 0f;
    float dist = 2.5f;

    private void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void LateUpdate () {
        if (Input.GetMouseButton (1) || Input.GetAxis ("Joy X") != 0 || Input.GetAxis ("Joy Y") != 0) { // Only do this if RM held or we get unintended...effects
            x += (Input.GetAxis ("Mouse X") + Input.GetAxis ("Joy X")) * xSpeed * multiplier; //Calc x based off Mouse/Joy X (If we use mouse Joy should be 0 and vice versa) * speed and 
            y -= (Input.GetAxis ("Mouse Y") + Input.GetAxis ("Joy Y")) * ySpeed * multiplier;
            y = ClampAngle (y, yMin, yMax); //Clamp the y angle
        }

        Quaternion rot = Quaternion.Euler (y, x, 0); //Calculating our rotation, and not chaning the z value of our cam
        Vector3 pos = rot * new Vector3 (0f, 0f, -dist) + player.position; //Here we calc ou new position and offset by our input distance (aka z) and track player position
        transform.rotation = rot; //Actually changing our cam's rotation
        transform.position = pos; //Actually changing our cam's position

    }

    static float ClampAngle (float angle, float min, float max) {
        if (angle < -360) //Will ensure we don't "flip" over our character when we move our cam, and get some 
            angle += 360; //funky positions and angles out of it
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp (angle, min, max);
    }
}