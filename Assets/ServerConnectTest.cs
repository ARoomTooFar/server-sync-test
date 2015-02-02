using UnityEngine;
using System.Collections;
using System;

public class ServerConnectTest : MonoBehaviour {
	private ARTFGS serverConnect;
	public DLOutputText dlOutputField;
	public ULOutputText ulOutputField;

	void Start () {
		serverConnect = gameObject.AddComponent<ARTFGS>();

		/* Download level data example 1 */
		//string dlLevelData = serverConnect.getLevel("5629499534213120");

		/* Download level data example 2 */
		string dlLevelData = serverConnect.getLevel("5066549580791808");
		
		//Generate error for attempting to download a level that doesn't exist
		//string dlLevelData = serverConnect.getLevel("123123123");

		Debug.Log(dlLevelData);
		if(dlLevelData == "")
			dlOutputField.ChangeText("ERROR: LEVEL DATA DOWNLOAD FAILED");
		else
			dlOutputField.ChangeText(dlLevelData);

		/* Upload level data example 1 */
		/*string ulLevelData = serverConnect.newLevel(456, "Level Name Test", "livedatatest", "draftdatatest");
		Debug.Log(ulLevelData);
		if(dlLevelData == "")
			ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
		else
			ulOutputField.ChangeText(ulLevelData);*/

		/* Upload level data example 2 */
		/*string ulLevelData = serverConnect.newLevel(123, "A Room Too Butts", "846254datafartshaha125");
		Debug.Log(ulLevelData);
		if(dlLevelData == "")
			ulOutputField.ChangeText("ERROR: LEVEL DATA UPLOAD FAILED");
		else
			ulOutputField.ChangeText(ulLevelData);*/

		/* Update level data example */
		/*string udLevelData = serverConnect.updateLevel("5066549580791808", "369", "Level Name Test Updated", "", "");
		Debug.Log(udLevelData);*/

		/* Delete level data example */
		/*string delLevelData = serverConnect.deleteLevel("5629499534213120");
		Debug.Log(delLevelData);*/
	}
}
