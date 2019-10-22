using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform player;
  
    [SerializeField] private float camPosX;
    [SerializeField] private float camPosY;
    [SerializeField] private float camPosZ;

    private float camPosYUpperLimit = 2.0f;
    private float camPosYLowerLimit = 0.95f;
    
    [SerializeField] private float camRotationX;
    [SerializeField] private float camRotationY;
    [SerializeField] private float camRotationZ;
   
    
    [Range(0f, 5f)] //Cap our turn rate so we don't make people sick
    [SerializeField] private float turnSpeed;
    private void Start () {
        offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
    }
    private void LateUpdate () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        
        //This creates an unintended zoom in effect with the camera at this value...which actually works BEAUTIFULLY
        if (offset.y > camPosYUpperLimit) { //Lock our camPosY's upper value to 2
            offset.y = camPosYUpperLimit;
        } else if (offset.y < camPosYLowerLimit) { //Lock camPosY's lower value to 0.95
            offset.y = camPosYLowerLimit;
        }
        
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}