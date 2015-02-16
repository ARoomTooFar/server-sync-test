using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private Farts serv;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;


	IEnumerator Start() {
		serv = gameObject.AddComponent<Farts>();

		// Download level example
        string dlLvlUri = serv.getLvlUri("5100084685438976");
        WWW dlLvlReq = new WWW(dlLvlUri);
        yield return dlLvlReq;

        // Use the downloaded level data
        string dlLvlData = dlLvlReq.text;

        Debug.Log(dlLvlData);

        if (serv.dataCheck(dlLvlData))
            dlOutputField.ChangeText(dlLvlData);
        else
            dlOutputField.ChangeText("ERROR: LEVEL DATA DOWNLOAD FAILED");

        // Upload level example
        Hashtable newLvlReq = serv.newLvlUri("Level Name Test", "123", "1337", "livedatatest", "draftdatatest");
        string ulLvlUri = (string)newLvlReq["uri"];
        WWWForm ulLvlForm = (WWWForm)newLvlReq["form"];

        WWW ulLvlReq = new WWW(ulLvlUri, ulLvlForm);
        yield return ulLvlReq;

        // Use the uploaded level data
        string ulLvlId = ulLvlReq.text;

        Debug.Log(ulLvlId);

        if (serv.dataCheck(ulLvlId))
            ulOutputField.ChangeText(ulLvlId);
        else
            ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
	}
}
