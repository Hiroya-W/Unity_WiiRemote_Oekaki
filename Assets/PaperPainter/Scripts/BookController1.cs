using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JohnsonCodeHK.UIControllerExamples.Popup
{
    public class BookController1 : MonoBehaviour
    {
        public UIControllerExample uic;
        public StatusManager sm;
        public MagicWordsCtl mw;

        public GameObject[] Books;

        public void BookChanger()
        {
            //メニューが開かれていなければ
            if (!sm.BookMenu)
            {
                //何か本が開いていたら
                if (sm.BookCh)
                {
                    //閉じる
                    Books[(int)mw.bs].GetComponent<BookController>().BookChanger();
                    return;
                }
                //メニューを開く
                sm.BookMenu = true;
                uic.Play();
            }
            //メニューが開いていたら
            else
            {
                //メニューを閉じる
                sm.BookMenu = false;
                uic.Play();
            }
        }
    }
}

