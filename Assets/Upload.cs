 /*using UnityEngine;
 using UnityEditor;
 using System.Collections;
  
 [InitializeOnLoad]
 public class Autorun {
    static Autorun() {
        Debug.Log("Upload Test");
	    dlFile("http://localhost:8080/api/levels/-EsLHlQv43iWKsGDPd-nRQ==");
     }

    static IEnumerator dlFile (string url) {
		WWW www = new WWW(url);
		yield return www;
	 	Debug.Log(www.text);
	}
 }*/
