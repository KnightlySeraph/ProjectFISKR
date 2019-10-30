using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;

    public GameObject hit_FX_Prefab;

    // Update is called once per frame
    void Update()
    {
        DetectCollision ();
    }

    //Detect Collision
    void DetectCollision () {           //Detect collision for weapon impact
        Collider[] hit = Physics.OverlapSphere (transform.position, radius, collisionLayer);

        if(hit.Length > 0) {            //If hit, hitFX is played related to position of the enemy and a message will display on the console that the enemy has been hit
            if (is_Player) {
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 0.5f;    //position y for hitFX to be displayed

                if(hit[0].transform.forward.x > 0) {
                    hitFX_Pos.x += 0.3f;
                } else if(hit[0].transform.forward.x < 0) {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate (hit_FX_Prefab, hitFX_Pos, Quaternion.identity);
            }
            print ("We hit the " + hit[0].gameObject.name);

            gameObject.SetActive (false);
        } 
    }
}
