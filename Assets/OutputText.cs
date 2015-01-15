using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputText : MonoBehaviour {
	public InputField test;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeText(string input) {
		test.text = input;
	}
}
