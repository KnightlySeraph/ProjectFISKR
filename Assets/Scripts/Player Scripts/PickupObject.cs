using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnTriggerEnter (Collider collider) {
        if (collider.CompareTag ("Player")) {
            for(int i = 0; i < inventory.slots.Length; i++) {
                if(inventory.isFull[i] == false) {
                    //item can be added to inventory
                    inventory.isFull[i] = true;
                    Instantiate (itemButton, inventory.slots[i].transform);
                    Destroy (gameObject);
                    break;
                }
            }
        }
        /*
        if(collider.gameObject.tag == "Player") {
            print ("item picked up");
            //Destroy (gameObject);
            gameObject.SetActive (false);
        }
        */
    }

    public Vector3 PickPosition;
    public Vector3 PickRotation;
}
