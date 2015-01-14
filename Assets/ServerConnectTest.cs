using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	public WWW ulFile;
	IEnumerator Start () {
		/*
		//Setup level upload example 1
		WWWForm postForm = new WWWForm ();
		postForm.AddField ("user_id", 123);
		postForm.AddField ("level_name", "A Room To Fart In");
		postForm.AddField ("live_level_data", "leveldatablahblahblah123");
		*/

		/*
		//Setup level upload example 2
		WWWForm postForm = new WWWForm ();
		postForm.AddField ("user_id", 456);
		postForm.AddField ("level_name", "A Room Too Butts");
		postForm.AddField ("live_level_data", "heyayayayayayaya");
		*/

		/*
		//Do the API POST request at /api/levels to upload to the server
		WWW upload = new WWW ("http://localhost:8080/api/levels/", postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log(upload.text);
		else
			Debug.Log(upload.error);
		*/

		//Do the API GET request at /api/levels/levelId to download the level from the server
		WWW www = new WWW("http://localhost:8080/api/levels/5785905063264256");
		yield return www;
		Debug.Log(www.text);
	}
}
