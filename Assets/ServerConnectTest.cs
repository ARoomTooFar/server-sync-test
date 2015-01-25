using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;

	IEnumerator Start () {
		//Do the API GET request at /api/levels/levelId to download the level from the server
		WWW downloadedData = new WWW("https://artf-gs.appspot.com/api/levels/5629499534213120");
		yield return downloadedData;
		dlOutputField.ChangeText(downloadedData.text);
		Debug.Log(downloadedData.text);

		/*
		//Generate error for trying to download a level that doesn't exist
		WWW download = new WWW("https://artf-gs.appspot.com/api/levels/1337");
		yield return download;
		dlOutputField.ChangeText(download.text);
		Debug.Log(download.text);
		*/

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

		/*
		//Generate error for not defining "level_name" in upload
		WWWForm postForm = new WWWForm ();
		postForm.AddField ("user_id", 789);
		postForm.AddField ("live_level_data", "this_will_be_denied");
		*/

		/*
		//Do the API POST request at /api/levels to upload to the server
		WWW uploadedData = new WWW ("https://artf-gs.appspot.com/api/levels/", postForm);
		*/

		/*
		//Generate error for sending a request to the incorrect URL
		WWW uploadedData = new WWW ("https://artf-gs.appspot.com/api", postForm);
		*/

		/*
		yield return uploadedData;
		if (uploadedData.error == null) {
			Debug.Log(uploadedData.text);
			ulOutputField.ChangeText(uploadedData.text);
		} else {
			Debug.Log(uploadedData.error);
			ulOutputField.ChangeText(uploadedData.error);
		}
		*/
	}
}
