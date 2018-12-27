using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

    public JohnsonCodeHK.UIControllerExamples.Popup.UIControllerExample[] Helps;

    public bool isshow;
    public int num;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ヘルプを開く　閉じる
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowHide();
        }

        //ヘルプが開かれているとき
        if (isshow)
        {
            //ページ切替 次
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextPage();
            }

            //ページ切替　前
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PreviousPage();
            }
        }
    }

    public void ShowHide()
    {
        //開いていたら
        if (isshow)
        {
            Helps[num].Hide();
            isshow = false;
        }
        //開いていなかったら
        else
        {
            Helps[0].Show();
            num = 0;
            isshow = true;
        }
    }

    public void NextPage()
    {
        //最後のページから一つ前まで
        if (num < Helps.Length - 1)
        {
            Helps[num].Hide();
            num += 1;
            Helps[num].Show();
        }
    }

    public void PreviousPage()
    {
        //最初のページから一つ次まで
        if (0 < num)
        {
            Helps[num].Hide();
            num -= 1;
            Helps[num].Show();
        }
    }
}
