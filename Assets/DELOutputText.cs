using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DELOutputText : MonoBehaviour {
    public InputField field;

    void Start ()
    {
        field.text = "No level deleted";
    }

    public void ChangeText (string input)
    {
        field.text = input;
    }
}
