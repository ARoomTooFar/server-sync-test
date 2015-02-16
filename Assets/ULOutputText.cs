using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ULOutputText : MonoBehaviour {
	public InputField field;
	// Use this for initialization
	void Start () {
		field.text = "No level uploaded";
	}
	
	public void ChangeText(string input) {
		field.text = input;
	}
}
