using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	private string pathtxt = "";

	// Use this for initialization
	void Start () {
		string txt = Application.dataPath;
		string txt2 = Application.persistentDataPath;
		pathtxt = "dataPath:"+txt+"\npersistentDataPath:"+txt2;
		Debug.Log(pathtxt);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.TextArea(new Rect(5,5,Screen.width,50), pathtxt);
	}
}