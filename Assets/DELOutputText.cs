using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DELOutputText : MonoBehaviour {
    public InputField field;
    // Use this for initialization
    void Start()
    {
        field.text = "No level deleted";
    }

    public void ChangeText(string input)
    {
        field.text = input;
    }
}
