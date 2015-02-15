using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private Farts farts;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;

	void Start () {
		farts = gameObject.AddComponent<Farts>();

		/* Download level data example */
		string dlLvlData = farts.getLevel("5328783104016384");
		Debug.Log("dlLvlData: " + dlLvlData);
		if(dlLvlData == "")
			dlOutputField.ChangeText("ERROR: LEVEL DATA DOWNLOAD FAILED");
		else
			dlOutputField.ChangeText(dlLvlData);

		/* Upload level data example */
		string ulLvlData = farts.newLevel("Level Name Test", "123", "1337", "livedatatest", "draftdatatest");
		Debug.Log("ulLvlData: " + ulLvlData);
		if(dlLvlData == "")
			ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
		else
			ulOutputField.ChangeText(ulLvlData);

		/* Update level data example */
		string udLvlData = farts.updateLevel("5610258080727040", "Updated Level Name Test", "456", "adfsdfasdfasf", "jkl;jlkj;klj;");
		Debug.Log("udLvlData: " + udLvlData);

		/* Delete level data example */
		string delLvlData = farts.deleteLevel("5047308127305728");
		Debug.Log("delLvlData:" + delLvlData);
	}
}
