using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
    public Text testtext;
    public string levelToLoad;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            StartCoroutine(DisplayLoadingScreen(levelToLoad));
        }
	}

    IEnumerator DisplayLoadingScreen(string level) {
        testtext.text = "PROGRESSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone) {
            yield return null;
        }
    }
}
