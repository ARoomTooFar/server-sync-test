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
        string dlLvlUri = serv.getLvlUri("4837301406400512");
        WWW dlLvlReq = new WWW(dlLvlUri);
        yield return dlLvlReq;

        // Use the downloaded level data
        string dlLvlData = dlLvlReq.text;

        if (serv.dataCheck(dlLvlData))
        {
            Debug.Log(dlLvlData);
            dlOutputField.ChangeText(dlLvlData);
        } 
        else
        {
            Debug.Log("ERROR: LEVEL DATA DOWNLOAD FAILED");
            dlOutputField.ChangeText("ERROR: LEVEL DATA DOWNLOAD FAILED");
        }


        // Upload level example
        Hashtable newLvlReq = serv.newLvlUri("Level Name Test", "123", "1337", "livedatatest", "draftdatatest");
        string ulLvlUri = (string)newLvlReq["uri"];
        WWWForm ulLvlForm = (WWWForm)newLvlReq["form"];

        WWW ulLvlReq = new WWW(ulLvlUri, ulLvlForm);
        yield return ulLvlReq;

        // Use the returned data
        string ulLvlId = ulLvlReq.text;

        if (serv.dataCheck(ulLvlId))
        {
            Debug.Log(ulLvlId);
            ulOutputField.ChangeText(ulLvlId);
        }
        else
        {
            Debug.Log("ERROR: LEVEL DATA UPLOAD FAILED");
            ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
        }


        // Update level example
        serv.updateLevel("4837301406400512", "Updated Level Name Test", "456", "adfsdfasdfasf", "jkl;jlkj;klj;");
	}
}
