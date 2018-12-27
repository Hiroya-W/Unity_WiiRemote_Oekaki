using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int maxDisplayCount = 2;
        Debug.Log(Display.displays.Length.ToString());
		for (int i=0; i<maxDisplayCount && i<Display.displays.Length; i++) {
            Debug.Log("Display[" + i.ToString() + "]を有効にします");
			Display.displays[i].Activate();
		}
		
		
	}
	

	// Update is called once per frame

	void Update () {
		//Cursor.lockState = CursorLockMode.Confined; //ウィンドウ内に留める
		}
	}


