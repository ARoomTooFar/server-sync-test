using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UDOutputText : MonoBehaviour {
    public InputField field;
    public bool changed = false;
    // Use this for initialization
    void Start()
    {
        field.text = "No level updated";
    }

    public void ChangeText(string input)
    {
        if (!changed) {
            Debug.Log(input);
            field.text = input;
            changed = true;
        }
    }
}
