using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MagicPlayer : NetworkBehaviour {

    public Controller1 Con1;
    public MagicWordsCtl Mwc;
    public ScreenCapture Sc;
    public SoundPlayer Sp;
	public objectController obj;
	public Wall sky;
	public StatusManager sm;

    public void MagicPlay()
    {
        //要求される分だけ描けていたら
        if(Mwc.maxdraw == Sc.capcounter)
        {
            Sp.PlaySinging();
			if(sm.HelperMode){//ヘルパーモード
				//雪だるま強制召喚
				//obj.createObj("plants",6);
                //obj.createObj("plants", 7);
                obj.createObj("plants", 0);
                obj.createObj("plants", 1);
                obj.createObj("plants", 2);
                //obj.createObj("plants", 3);
                obj.createObj("plants", 4);
                //obj.createObj("plants", 5);
                obj.createObj("plants", 8);
                //obj.createObj("plants", 9);
                //obj.createObj("plants", 10);
                //obj.createObj("plants", 11);
                //obj.createObj("plants", 12);
                //obj.createObj("plants", 13);
                //obj.createObj("plants", 14);
                //obj.createObj("plants", 15);
                obj.createObj("plants", 16);
                //obj.createObj("plants", 17);
                obj.createObj("plants", 18);
            }
            else{
				if (Mwc.variety == 0)//Box
				{
					//プレゼント
					if (Mwc.page == 2)
					{
						//プレゼントを出現させる！
						Debug.Log("プレゼントだよ！");
						obj.createObj ("box", 5);
					}if (Mwc.page == 4) {
						//Tresure Box
						obj.createObj("box",18);
					}
				}
				if (Mwc.variety == 1) {//Plants
					if (Mwc.page == 2) {
						//Tree
						obj.createObj ("plants", 12);
					}
					if (Mwc.page == 4) {
						//Christmas Tree
						obj.createObj ("plants", 8);
					}
					if (Mwc.page == 6) {
						//Palm Tree
						obj.createObj ("plants", 13);
					}
					if (Mwc.page == 8) {
						//Snow Tree
						obj.createObj ("plants", 11);
					}
					if (Mwc.page == 10) {
						//Snowman
						obj.createObj ("plants", 6);
						obj.createObj ("plants", 7);
					}
					if (Mwc.page == 12) {
						//Flower
						obj.createObj ("plants", 10);
					}
					if (Mwc.page == 14) {
						//Bird
					}
					if (Mwc.page == 16) {
						//Mushroom
						obj.createObj ("plants", 4);
					}
				}
				if (Mwc.variety == 2) {//Tools
					if (Mwc.page == 2) {
						//Swing
						obj.createObj("tools",9);
					}
					if (Mwc.page == 4) {
						//Fence
						obj.createObj("tools",0);
					}
					if (Mwc.page == 6) {
						//MailBox
						obj.createObj("tools",2);
					}
					if (Mwc.page == 8) {
						//House
						obj.createObj("tools",1);
					}
					if (Mwc.page == 10) {
						//Boat
						obj.createObj("tools",15);
					}
					if (Mwc.page == 12) {
						//Parasol
						obj.createObj("tools",16);
					}
					if (Mwc.page == 14) {
						//SurfBoard
						obj.createObj("tools",14);
					}
					if (Mwc.page == 16) {
						//Watering Can
						obj.createObj("tools",17);
					}
					if (Mwc.page == 18) {
						//Santa's Hat
					}
					if (Mwc.page == 20) {
						//Sled??
					}
				}
				if (Mwc.variety == 3) {//Weather
					if (Mwc.page == 2) {
						//Sunny
						sky.RpcChangeSkyboxToSunny();
					}
					if (Mwc.page == 4) {
						//Rain
						sky.RpcChangeSkyboxToRainy();
					}
					if (Mwc.page == 6) {
						//Snow
						sky.RpcChangeSkyboxToSnowy();
					}
				}
			}
            
            //描いたものをすべてリセットする
            for (int i = 0; i < Con1.DetectImgNum.Length; i++)
            {
                Con1.DetectImgNum[i] = 0;
                Con1.LastImageDelete();
            }
        }
    }

    public void MagicPlay1()
    {
        //数値の連結
        string str = null;
        for (int i = 0; i < Con1.DetectImgNum.Length; i++)
        {
            str += Con1.DetectImgNum[i];
        }

        //連結後の文字列から判別
        //魔法陣 + 丸
        if(str == "3100")
        {
            Debug.Log("魔法陣を形成する！");
        }
        else
        {
            Debug.Log("魔法に失敗した...。");
        }

        //描いたものをすべてリセットする
        AllReset();
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
