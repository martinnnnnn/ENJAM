using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class printscorefinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float score = PlayerPrefs.GetFloat("score");

        int _fMinutes = Mathf.FloorToInt(score / 60F);
        int _fSecondes = Mathf.FloorToInt(score - _fMinutes * 60);
        string scorestring = string.Format("{0:00}:{1:00}", _fMinutes, _fSecondes);

        GetComponent<Text>().text = scorestring;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
