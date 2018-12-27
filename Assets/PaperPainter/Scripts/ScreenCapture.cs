using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCapture : MonoBehaviour {

    public StatusManager sm;
    public RawImage ShowImage;

	public int capcounter;
    public bool saveflag;
    public Renderer rend;
    public GameObject DrawCursor;

    public List<Texture2D> TextureList = new List<Texture2D>();

    // Use this for initialization
    void Start () {
        //保存先ディレクトリ
        string SaveDir = Application.dataPath + "/ScreenShots";

        Debug.Log(Application.dataPath);

        Debug.Log("保存フォルダの存在チェック");
        if(Directory.Exists(SaveDir))
        {
            Debug.Log("Success : フォルダが存在します");
        }
        else
        {
            Debug.Log("Error : フォルダが存在しません");
            Directory.CreateDirectory(SaveDir);
            Debug.Log("フォルダを生成しました");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Capture()
	{
        if(capcounter < 4)
        {
            ShowImage.color = new Color(ShowImage.color.r, ShowImage.color.g, ShowImage.color.b, 0);
            //capcounter += 1;
            //Application.CaptureScreenshot ("Assets/ScreenShots/ss" + capcounter.ToString() + ".png");
            StartCoroutine(CreateScreenShot());
        }
    }

    public void CapcounterReset()
    {
        capcounter = 0;
    }

    IEnumerator CreateScreenShot()
    {
        
        if (sm.HelperMode)
        {
            DrawCursor.SetActive(false);
        }

        int c = capcounter + 1;
        string str = Application.dataPath + "/ScreenShots/ss" + c.ToString() + ".png";
        if ((File.Exists(str) == true))
        {
            Debug.Log("ファイルが存在するため削除します");
            // ファイル削除
            File.Delete(str);
            while (File.Exists(str) == true)
            {
                yield return null;
            }
        }

        // スクリーンショットを撮る
        Debug.Log("撮影します");
        Application.CaptureScreenshot(str);


        while (File.Exists(str) == false)
        {
            yield return null;
        }
        Debug.Log("撮影が完了しました");
        capcounter += 1;
        saveflag = true;
        

        if (sm.HelperMode)
        {
            DrawCursor.SetActive(true);
        }        
    }

    public void SaveTexture()
    {
        Texture2D tex = rend.material.mainTexture as Texture2D;
        TextureList.Add(tex);
        capcounter++;
        /** Listの使い方
         * myList.Add(newObj1);    //GameObject型 newObj1をmyListに加える
         * GameObject newObj2 = myList[0]; //Listへのアクセス
         * myList.RemoveAt(0); //Listの0番目の要素を消す
         * myList.Clear(); //Listすべての要素を削除
         * 
         * List<int> intList = new List<int>();
         * intList.Add(1); // intList = {1}
         * intList.Add(2); // intList = {1,2}
         * intList.Add(3); // intList = {1,2,3}
         * intList.RemoveAt(1);    // intList = {1,3}
         * int b = intList[1]; // bには3が入る
        */

    }

}
