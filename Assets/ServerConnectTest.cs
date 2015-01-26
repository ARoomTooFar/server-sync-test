using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private ARTFGS serverConnect;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;

	void Start () {
		serverConnect = gameObject.AddComponent<ARTFGS> ();
		/*
		//Do the API GET request at /api/levels/levelId to download the level from the server
		WWW downloadedData = new WWW("http://localhost:8080/api/levels/5629499534213120");
		yield return downloadedData;
		dlOutputField.ChangeText(downloadedData.text);
		Debug.Log(downloadedData.text);
		*/

		/*
		//Generate error for trying to download a level that doesn't exist
		WWW downloadedData = new WWW("https://artf-gs.appspot.com/api/levels/1337");
		yield return downloadedData;
		dlOutputField.ChangeText(downloadedData.text);
		Debug.Log(downloadedData.text);
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
		WWW uploadedData = new WWW ("http://localhost:8080/api/levels/", postForm);
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

		/* Download level data example */
		string dlLevelData = serverConnect.getLevel("6093630880088064");
		
		//Generate error for attempting to download a level that doesn't exist
		//string levelData = serverConnect.getLevel("123123123");

		Debug.Log(dlLevelData);
		if(dlLevelData == "")
			dlOutputField.ChangeText("ERROR: LEVEL DATA DOWNLOAD FAILED");
		else
			dlOutputField.ChangeText(dlLevelData);

		/* Upload level data example */
		/*string ulLevelData = serverConnect.sendNewLevel(456, "Level Name Test", "livedatatest", "draftdatatest");
		Debug.Log(ulLevelData);
		if(dlLevelData == "")
			ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
		else
			ulOutputField.ChangeText(ulLevelData);*/

	}
}
