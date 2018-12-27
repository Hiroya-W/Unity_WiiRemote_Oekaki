using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Controller1 Con1;
    public MagicWordsCtl mw;

    //ヘルパーモード
    public bool HelperMode;
    //オープンキャンパスモード
    //魔法語の組み合わせがオープンキャンパス用になる
    public bool OCMode;
    //ユーザーが描く動作を取ったとき
    public bool Drawflag;
    public bool BookCh;
    public bool BookMenu;

    //詠唱待ち
    public bool Singwait;

    //一致率
    public float rate;

    public GameObject DrawCursor;

    public Text OCMODEtxt;

    public void ChgHelperMode()
    {
        HelperMode = !HelperMode;
        AllReset();
        //ヘルパーモードが有効の時
        //疑似カーソルが無効だったら有効にする
        if (HelperMode)
        {
            if (!DrawCursor.activeInHierarchy)
            {
                DrawCursor.SetActive(true);

                int variety = mw.GetSelectedBookNum();
                int page = mw.GetBookPage();
                mw.MagicWordsChg(variety, page);
            }
        }
        else
        {
            int variety = mw.GetSelectedBookNum();
            int page = mw.GetBookPage();
            DrawCursor.SetActive(false);
            mw.MagicWordsChg(variety, page);
        }
    }

    public void ChangeOCMode()
    {
        OCMode = !OCMode;
        Debug.Log("オープンキャンパスモード:" + OCMode.ToString());
        OCMODEtxt.text = "OCMode:" + OCMode.ToString();
    }

    private void Update()
    {
        //通常モードではマウス入力に従う
        if (!HelperMode)
        {
            //マウス入力があれば
            if (Input.GetMouseButton(0))
            {
                Drawflag = true;
            }
            else
            {
                Drawflag = false;
            }
        }
    }

    public void SetBookMenu(bool flag)
    {
        BookMenu = flag;
    }

    //描いたものをすべてリセットする
    void AllReset()
    {
        for (int i = 0; i < Con1.DetectImgNum.Length; i++)
        {
            Con1.DetectImgNum[i] = 0;
            Con1.LastImageDelete();
        }
    }
}
