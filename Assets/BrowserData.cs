using UnityEngine;
using System.Collections;

public class BrowserData : MonoBehaviour {
    public string levelId = "";

	// Use this for initialization
	void Start () {
        
	}

    public void callBrowserFunction() {
        Application.ExternalCall("sendLevelId", 0);
    }

    public void getLevelId(string browserLevelId) {
        Debug.Log("getLevelId called");
        levelId = browserLevelId;
        Debug.Log("input level ID: " + browserLevelId);
    }
}
