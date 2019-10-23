using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    // Initially I wish to use this to setup some basic testing to use 
    //with our input field to test "cheats"/dev shortcuts.
    public GameObject inputCommandString;
    private InputField inputField;
    public GameObject myPrefab;
    private void Awake () {
        inputCommandString.SetActive (false);
        inputField = inputCommandString.GetComponent<InputField>();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.F1)) {
            inputCommandString.SetActive (true);
        }
    }

    public void commandProcesser () { //Will process our input command, automagically gets the value on submit
        inputCommandString.SetActive (false);
        Debug.Log (inputField.text);
        //Will need lots of debug statements...so big IF tree for everything.
        if (inputField.text == "111") {
            Instantiate(myPrefab, new Vector3(0, 30, 0), Quaternion.identity);
            Debug.Log ("TODO: Give GodMode");
        }
    }
}