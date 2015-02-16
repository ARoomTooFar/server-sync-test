using UnityEngine;
using System.Collections;

public class Farts : MonoBehaviour {
	const string SERVERURI = "http://localhost:8081"; //local server
	//const string SERVERURI = "https://api-dot-artf-server.appspot.com"; //live server
	const string LEVELPATH = "/levels/";

    public string getLvlUri(string levelId)
    {
        return SERVERURI + LEVELPATH + levelId;
    }

    public Hashtable newLvlUri(string lvlName, string gameAcctId, string machId, string liveLvlData = "", string draftLvlData = "")
    {
        string uri = SERVERURI + LEVELPATH;

        WWWForm form = new WWWForm();
        form.AddField("level_name", lvlName);
        form.AddField("game_acct_id", gameAcctId);
        form.AddField("mach_id", machId);
        if (liveLvlData != "")
            form.AddField("live_level_data", liveLvlData);
        if (draftLvlData != "")
            form.AddField("draft_level_data", draftLvlData);

        Hashtable newLvlReq = new Hashtable();
        newLvlReq.Add("uri", uri);
        newLvlReq.Add("form", form);

        return newLvlReq;
    }

    // Checks if returned data is valid or not. Returns true if the data is valid, false otherwise.
    public bool dataCheck(string input) {
        if (input == "") return false;
        return true;
    }
	
	public string getLevel(string levelId) {
		WWW www = new WWW(SERVERURI + LEVELPATH + levelId);
        float elapsedTime = 0.0f;
        float cancelTime = 10000f;
		
		StartCoroutine(httpRequest(www));
		while(www.isDone == false) {
            if (elapsedTime >= cancelTime) {
                Debug.LogError("ERROR: Request timeout");
                return "";
            }

            elapsedTime += Time.deltaTime;
            //Debug.Log("HTTP request time elapsed: " + elapsedTime);
		}
		
		return www.text;
	}
	
	public string newLevel(string lvlName, string gameAcctId, string machId, string liveLvlData="", string draftLvlData="") {
        float elapsedTime = 0.0f;
        float cancelTime = 10000f;
        
        WWWForm form = new WWWForm();
		form.AddField("level_name", lvlName);
		form.AddField("game_acct_id", gameAcctId);
		form.AddField("mach_id", machId);
		if(liveLvlData != "")
			form.AddField ("live_level_data", liveLvlData);
		if(draftLvlData != "")
			form.AddField ("draft_level_data", draftLvlData);

		WWW www = new WWW(SERVERURI + LEVELPATH, form);

		StartCoroutine(httpRequest(www));
        while (www.isDone == false)
        {
            if (elapsedTime >= cancelTime)
            {
                Debug.LogError("ERROR: Request timeout");
                return "";
            }

            elapsedTime += Time.deltaTime;
            //Debug.Log("HTTP request time elapsed: " + elapsedTime);
        }
		
		return www.text;
	}

	public void updateLevel(string lvlId, string lvlName="", string gameAcctId="", string liveLvlData="", string draftLvlData="") {
		WWWForm form = new WWWForm();
		form.AddField ("flag", "update");
		if(lvlName != "")
			form.AddField ("level_name", lvlName);
		if(gameAcctId != "")
			form.AddField ("game_acct_id", gameAcctId);
		if(liveLvlData != "")
			form.AddField ("live_level_data", liveLvlData);
		if(draftLvlData != "")
			form.AddField ("draft_level_data", draftLvlData);
		
		WWW www = new WWW(SERVERURI + LEVELPATH + lvlId, form);
		StartCoroutine(httpRequest(www));
	}
	
	public string deleteLevel(string lvlId) {
        float elapsedTime = 0.0f;
        float cancelTime = 10000f;

		WWWForm form = new WWWForm();
		form.AddField ("flag", "delete");
		form.AddField ("level_id", lvlId);

        WWW www = new WWW(SERVERURI + LEVELPATH + lvlId, form);
		StartCoroutine(httpRequest(www));

        while (www.isDone == false)
        {
            if (elapsedTime >= cancelTime)
            {
                Debug.LogError("ERROR: Request timeout");
                return "";
            }

            elapsedTime += Time.deltaTime;
            //Debug.Log("HTTP request time elapsed: " + elapsedTime);
        }
		
		return www.text;
	}
	
	IEnumerator httpRequest(WWW www) {
		yield return www;
		
		if (www.error == null) {
			Debug.Log("WWW SUCCESS: " + www.text);
		} else {
			Debug.Log("WWW ERROR: " + www.error);
		}
	}
}
