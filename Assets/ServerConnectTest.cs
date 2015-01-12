using UnityEngine;
using System.Collections;

public class ServerConnectTest : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		Debug.Log("yes");
		WWW www = new WWW("http://localhost:8080/api/levels/-EsLHlQv43iWKsGDPd-nRQ==");
		yield return www;
		Debug.Log(www.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
