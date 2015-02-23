using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private Farts serv;
    private WWW lvlUpdate;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;
    public UDOutputText udOutputField;
    public DELOutputText delOutputField;


	IEnumerator Start() {
		serv = gameObject.AddComponent<Farts>();

		// Download level example
        WWW dlLvlReq = serv.getLvlWww("5785905063264256");
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
            Debug.Log("ERROR: LEVEL UPLOAD FAILED");
            ulOutputField.ChangeText("ERROR: LEVEL UPLOAD FAILED");
        }


        // Update level example
        lvlUpdate = serv.updateLvl("5785905063264256", "Updated Level Name Test", "456", "adfsdfasdfasf", "jkl;jlkj;klj;");

        // Delete level example [WARNING MAY FREEZE WEB PLAYER]
        /*string delLvlId = serv.delLvl("6737257499197440");

        // Use the returned data
        if (serv.dataCheck(delLvlId))
        {
            Debug.Log(delLvlId);
            delOutputField.ChangeText(delLvlId);
        }
        else
        {
            Debug.Log("ERROR: LEVEL DELETE FAILED");
            delOutputField.ChangeText("ERROR: LEVEL DATA DELETE FAILED");
        }*/
    }


    void Update() {
        // Use the returned data from update level request's coroutine
        if (lvlUpdate != null)
        {
            if (lvlUpdate.isDone && lvlUpdate.error == null)
            {
                udOutputField.ChangeText(lvlUpdate.text);
            }
            else if (lvlUpdate.error != null)
            {
                udOutputField.ChangeText("ERROR: LEVEL UPDATE FAILED");
            }
        }
    }
}
