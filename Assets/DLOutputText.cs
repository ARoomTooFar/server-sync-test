using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DLOutputText : MonoBehaviour {
	public InputField field;
	// Use this for initialization
	void Start () {
		field.text = "No level data downloaded";
	}

	public void ChangeText(string input) {
		field.text = input;
	}
}
