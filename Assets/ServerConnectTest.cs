using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	public WWW ulFile;
	IEnumerator Start () {
		Debug.Log("Hello world!");

		//Test file download
		/*WWW dlFile = new WWW ("http://localhost:8080/api/levels/-EsLHlQv43iWKsGDPd-nRQ==");
		yield return dlFile;
		Debug.Log (dlFile.text);*/

		//Test file upload
		string ulFilePath = Application.dataPath + "/upload-dis.txt";
		Debug.Log (ulFilePath);
		ulFile = new WWW("file:///" + ulFilePath);
		yield return ulFile;
		Debug.Log (ulFile.data);

		WWWForm postForm = new WWWForm ();
		postForm.AddField ("filestr", "test123");
		//postForm.AddBinaryData ("file", ulFile.bytes, "upload-dis.txt", "text/plain");
		//Debug.Log (ulFile.bytes);

		//Debug.Log (postForm.headers.Keys);
		Debug.Log (postForm.headers["Content-Type"]);
		foreach (String header in postForm.headers.Keys) {
			Debug.Log (header);
		}

		WWW upload = new WWW ("http://localhost:8080/api/levels/", postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log(upload.text);
		else
			Debug.Log(upload.error);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
