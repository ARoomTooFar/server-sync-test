using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	public WWW ulFile;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;

	IEnumerator Start () {
		//Do the API GET request at /api/levels/levelId to download the level from the server
		WWW download = new WWW("http://localhost:8080/api/levels/5785905063264256");
		yield return download;
		dlOutputField.ChangeText(download.text);
		Debug.Log(download.text);
		
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
		postForm.AddField ("live_level_data", "heyayayayayayaya!!");
		*/

		//Generate error for not defining "level_name" in upload
		WWWForm postForm = new WWWForm ();
		postForm.AddField ("user_id", 789);
		postForm.AddField ("live_level_data", "this_will_be_denied");

		//Do the API POST request at /api/levels to upload to the server
		WWW uploadedData = new WWW ("http://localhost:8080/api/levels/", postForm);

		//Generate error for sending a request to the incorrect URL
		//WWW uploadedData = new WWW ("http://localhost:8080/api", postForm);

		yield return uploadedData;
		if (uploadedData.error == null) {
			Debug.Log(uploadedData.text);
			ulOutputField.ChangeText(uploadedData.text);
		} else {
			Debug.Log(uploadedData.error);
			ulOutputField.ChangeText(uploadedData.error);
		}
	}
}
