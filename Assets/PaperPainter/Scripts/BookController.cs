using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour {

    public StatusManager sm;
    public Controller1 Ctl1;

    //移動スピード
    public float speed;

    //状態
    public bool offflag;
    public bool isrunning;
    //public bool bookch;

    public Vector3 poti;

    IEnumerator Move;

    public void BookChanger()
    {
        if (!isrunning)
        {
            isrunning = true;

            //描いたものをすべてリセットする
            for (int i = 0; i < Ctl1.DetectImgNum.Length; i++)
            {
                Ctl1.DetectImgNum[i] = 0;
                Ctl1.LastImageDelete();
            }

            Move = MoveBook();
            StartCoroutine(Move);
        }
        else
        {
            //停止
            StopCoroutine(Move);
            offflag = !offflag;
            isrunning = false;

            //戻す
            Move = MoveBook();
            isrunning = true;
            StartCoroutine(Move);
        }
    }

    IEnumerator MoveBook()
    {
        sm.BookCh = !sm.BookCh;
        Transform tf = this.GetComponent<Transform>();
        Vector3 Bookmovement;
        while (true)
        {
            Vector3 Bookpoti = tf.localPosition;
            //表示されているときfalse 表示していない時true
            if (!offflag)
            {
                Bookmovement = new Vector3(-30,0,0);
                tf.localPosition = Vector3.Lerp(Bookpoti, Bookmovement, speed * Time.deltaTime);
            }
            else
            {
                Bookmovement = new Vector3(-30, 290, 0);
                tf.localPosition = Vector3.Lerp(Bookpoti, Bookmovement, speed * Time.deltaTime);
            }

            if (Mathf.Abs(Bookpoti.y - Bookmovement.y) < 0.1f)
                break;
            yield return null;
        }
        offflag = !offflag;
        isrunning = false;
    }



}
