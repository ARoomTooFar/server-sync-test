using UnityEngine;
using System.Collections;

public class ARTFGS : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
		Debug.Log("ARTFGS object started");
	}
	*/
	
	/*
	// Update is called once per frame
	void Update () {
	
	}*/

	public string getLevel(string levelId) {
		WWW www = new WWW("http://localhost:8080/api/levels/" + levelId);
		//WWW www = new WWW("https://artf-gs.appspot.com/api/levels/" + levelId);
		StartCoroutine(httpRequest(www));
		while(www.isDone == false) {
			//Debug.Log("HTTP request in progress...");
		}

		if(www.text == "")
			return "ERROR: LEVEL DATA DOWNLOAD FAILED";	
		else
			return www.text;
	}

	IEnumerator httpRequest(WWW www) {
		yield return www;

		if (www.error == null) {
			Debug.Log("WWW SUCCESS: " + www.url);
		} else {
			Debug.Log("WWW ERROR: " + www.error);
		}
	}
}
