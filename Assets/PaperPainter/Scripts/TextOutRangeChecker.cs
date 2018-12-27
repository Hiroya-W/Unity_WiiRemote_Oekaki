using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutRangeChecker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        Text text = this.GetComponent<Text>();
        string str = text.text;
        if(str.Length > 10000)
        {
            text.text = "";
        }
    }
}
