using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private Farts serv;
    private WWW lvlUpdate;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;
    public UDOutputText udOutputField;


	IEnumerator Start() {
		serv = gameObject.AddComponent<Farts>();

		// Download level example
        WWW dlLvlReq = serv.getLvlWww("4837301406400512");
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


        /*// Upload level example
        WWW ulLvlReq = serv.newLvlWww("Level Name Test", "123", "1337", "livedatatest", "draftdatatest");
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
        }*/


        // Update level example
        lvlUpdate = serv.updateLevel("4837301406400512", "Updated Level Name Test", "456", "adfsdfasdfasf", "jkl;jlkj;klj;");
	}


    void Update() {
        if (lvlUpdate != null)
        {
            if (lvlUpdate.isDone && lvlUpdate.error == null)
            {
                udOutputField.ChangeText(lvlUpdate.text);
            }
        }
    }
}
