using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeavtivateGameObject : MonoBehaviour
{
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("DeactivateAfterTime", timer);
    }

    void DeactivateOverTime () {
        gameObject.SetActive (false);

    }
}
