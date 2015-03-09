using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ULOutputText : MonoBehaviour {
	public InputField field;

	void Start ()
    {
		field.text = "No level uploaded";
	}
	
	public void ChangeText (string input)
    {
		field.text = input;
	}
}
