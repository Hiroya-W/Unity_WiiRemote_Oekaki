using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevelopMenuController : MonoBehaviour {

	//Menu Object
	public GameObject MenuObj;

    //Console Object
    public GameObject ConsoleObj;

	//IR Dot Canvas
	public Canvas IRCanvas;

	//移動スピード
	public float speed;

	//状態
	public bool offflag;
    public bool offflag1;
	public bool isrunning;

	public Vector3 poti;

    int count;

    public Button[] RightBtns;
    public Button[] AllBtns;
    bool RightBtnsdisEnable;

    public void MenuChanger(){
		if(!isrunning){
			isrunning = true;
            if(count == 0)
            {
                StartCoroutine(MoveMenu());
                StartCoroutine(MoveConsole());
                count = 1;
            }
            else if(count == 1)
            {
                StartCoroutine(MoveConsole());
                count = 2;
            }
            else if(count == 2)
            {
                StartCoroutine(MoveMenu());
                count = 0;
            }
			
		}		
	}

    IEnumerator MoveConsole()
    {
        Transform tf = ConsoleObj.GetComponent<Transform>();
        Vector3 Movement;

        while (true)
        {
            Vector3 Consolepoti = tf.localPosition;

            //表示されているときtrue 表示していない時false
            if (offflag1)
            {
                Movement = new Vector3(-280, 0, 0);
                tf.localPosition = Vector3.Lerp(Consolepoti, Movement, speed * Time.deltaTime);
            }
            else
            {
                Movement = Vector3.zero;
                tf.localPosition = Vector3.Lerp(Consolepoti, Movement, speed * Time.deltaTime);
            }

            if (Mathf.Abs(Consolepoti.x - Movement.x) < 0.1f)
                break;
            yield return null;
        }
        offflag1 = !offflag1;
        isrunning = false;
    }

	IEnumerator MoveMenu(){
		Transform tf = MenuObj.GetComponent<Transform>();
		RectTransform IRrect = IRCanvas.GetComponent<RectTransform>();		
		//Debug.Log(IRrect.localPosition);
		Vector3 Menumovement;
		Vector3 IRmovement;
		while(true){
			Vector3 Menupoti = tf.localPosition;
			Vector3 IRpoti = IRrect.localPosition;
			//表示されているときfalse 表示していない時true
			if(!offflag){
				Menumovement = new Vector3(-250,0,0);
				IRmovement = new Vector3(14,-3.4f,-0.1f);
				tf.localPosition = Vector3.Lerp(Menupoti,Menumovement,speed * Time.deltaTime);
				IRrect.localPosition = Vector3.Lerp(IRpoti,IRmovement,speed * Time.deltaTime); 
			}
			else{
				Menumovement = Vector3.zero;
				IRmovement = new Vector3(6.8f,-3.4f,-0.1f);
				tf.localPosition = Vector3.Lerp(Menupoti,Menumovement,speed * Time.deltaTime);
				IRrect.localPosition = Vector3.Lerp(IRpoti,IRmovement,speed * Time.deltaTime); 
			}

			if(Mathf.Abs(Menupoti.x - Menumovement.x) < 0.1f)
				break;
			yield return null;
		}
		offflag = !offflag;
		isrunning = false;
	}

    public void RightBtnsMover()
    {
        float Movement;
        //表示されていたら右に移動
        if (!RightBtnsdisEnable)
        {
            Movement = 200;
        }
        //表示されていなかったら左に移動
        else
        {
            Movement = -200;
        }

        //全部のボタンに対して適応
        for (int i = 0; i < RightBtns.Length; i++)
        {
            RectTransform rt = RightBtns[i].GetComponent<RectTransform>();
            rt.localPosition = new Vector3(rt.localPosition.x + Movement, rt.localPosition.y, rt.localPosition.z);
        }

        RightBtnsdisEnable = !RightBtnsdisEnable;
    }

    public void AllBtnsMover()
    {
        float Movement = 1000;

        //全部のボタンに対して適応
        for (int i = 0; i < AllBtns.Length; i++)
        {
            RectTransform rt = AllBtns[i].GetComponent<RectTransform>();
            rt.localPosition = new Vector3(rt.localPosition.x + Movement, rt.localPosition.y, rt.localPosition.z);
        }
    }
}
