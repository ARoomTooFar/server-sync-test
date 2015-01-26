using UnityEngine;
using System.Collections;

public class ARTFGS : MonoBehaviour {
	const string SERVERURI = "http://localhost:8080/"; //local server
	//const string SERVERURI = "https://artf-gs.appspot.com/"; //live server
	const string LEVELPATH = "api/levels/";

	public string getLevel(string levelId) {
		//Connect to local server
		WWW www = new WWW(SERVERURI + LEVELPATH + levelId);

		StartCoroutine(httpRequest(www));
		while(www.isDone == false) {
			//Debug.Log("HTTP request in progress...");
		}

		return www.text;
	}

	public string sendNewLevel(int userId, string levelName, string liveLevelData = "", string draftLevelData = "") {
		WWWForm form = new WWWForm();
		form.AddField ("user_id", userId);
		form.AddField ("level_name", levelName);

		if(liveLevelData != "")
			form.AddField ("live_level_data", liveLevelData);
		if(draftLevelData != "")
			form.AddField ("draft_level_data", draftLevelData);

		WWW www = new WWW(SERVERURI + LEVELPATH, form);
		StartCoroutine(httpRequest(www));
		while(www.isDone == false) {
			//Debug.Log("HTTP request in progress...");
		}

		return www.text;
	}

	IEnumerator httpRequest(WWW www) {
		yield return www;

		/*if (www.error == null) {
			Debug.Log("WWW SUCCESS: " + www.url);
		} else {
			Debug.Log("WWW ERROR: " + www.error);
		}*/
	}
}
