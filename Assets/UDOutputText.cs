using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UDOutputText : MonoBehaviour {
    public InputField field;

    void Start ()
    {
        field.text = "No level updated";
    }

    public void ChangeText (string input)
    {
        field.text = input;
    }
}
