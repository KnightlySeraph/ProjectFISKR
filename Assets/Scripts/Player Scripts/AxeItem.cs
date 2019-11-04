using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeItem : MonoBehaviour
{
    //public GameObject effect;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    public void Use () {
        print ("click");
        //gameObject.SetActive (true);
        //Destroy (gameObject);
    }
}
