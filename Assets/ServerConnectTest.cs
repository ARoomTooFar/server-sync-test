using UnityEngine;
using System.Collections;

public class ServerConnectTest : MonoBehaviour {
	
	IEnumerator Start () {
		Debug.Log("Hello world!");

		//Test file download
		WWW dlFile = new WWW ("http://localhost:8080/api/levels/-EsLHlQv43iWKsGDPd-nRQ==");
		yield return dlFile;
		Debug.Log (dlFile.text);

		//Test file upload
		string ulFilePath = Application.dataPath + "/upload-dis.txt";
		Debug.Log (ulFilePath);
		WWW ulFile = new WWW("file:///" + ulFilePath);
		yield return ulFile;
		Debug.Log (ulFile.GetType());

		WWWForm postForm = new WWWForm ();
		postForm.AddBinaryData ("file", ulFile.bytes, "upload-dis.txt", "text/plain");
		Debug.Log (postForm.data);
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
