using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicWordsCtl : MonoBehaviour {

    //本の種類選択
    public enum BookSel
    {
        BOXES,
        PLANTS,
        TOOLS,
        WEATHER
    }
    public BookSel bs;

    //下絵の用意
    public Texture2D[] ClearPictures;
    public Texture2D[] HelperPictures;

    public Texture2D[] Operations;
    public Texture2D[] CompOperations;

    public Texture2D[] Boxes;
    public Texture2D[] CompBoxes;

    public Texture2D[] Plants;
    public Texture2D[] CompPlants;

    public Texture2D[] Tools;
    public Texture2D[] CompTools;

    public Texture2D[] Weathers;
    public Texture2D[] CompWeathers;

    //魔術本
    public GameObject[] Books;    

    //描いた枚数
    public ScreenCapture sc;

    //ヘルパーモード確認
    public StatusManager sm;

    //描けたときの演出
    public ParticleSystem SphereParticle;

    //表示するためのRawImage
    public RawImage ShowImage;

    //比較用のテクスチャ
    public Texture2D CompImage;

    //描くべき枚数
    public int maxdraw;
    public int variety;
    public int page;

    private void Start()
    {
        SphereParticle.Stop();

        variety = GetSelectedBookNum();
        page = GetBookPage();
        MagicWordsChg(variety, page);
    }

    private void Update()
    {
        variety = GetSelectedBookNum();
        page = GetBookPage();
                
        //下絵の変更
        if (!sc.saveflag)
        {
            //通常モード時
            if (!sm.OCMode)
            {
                MagicWordsChg(variety, page);
            }
            //オープンキャンパスモード
            else
            {
                MagicWordsChgOC(variety, page);
            }
            
        }        

        //もし枚数かけたら
        if ((page != 0) && (maxdraw == sc.capcounter))
        {
            sm.Singwait = true;
            ShowImage.texture = null;
            //SphereParticle.Play();
            StartCoroutine(PlaySphereParticle());
        }
        else
        {
            sm.Singwait = false;
            SphereParticle.Stop();
        }
    }

    public void MagicWordsChg(int variety, int page)
    {
        //描いた枚数 
        int count = sc.capcounter;

        //ヘルパーモードの時
        if (sm.HelperMode)
        {
            maxdraw = 3;
            //1つ目 魔法陣
            if (count == 0)
            {
                ShowImage.texture = HelperPictures[0];
                CompImage = HelperPictures[0];
            }
            //2つ目 置く
            else if (count == 1)
            {
                ShowImage.texture = HelperPictures[1];
                CompImage = HelperPictures[1];
            }
            //3つ目 雪だるま
            else if (count == 2)
            {
                ShowImage.texture = HelperPictures[2];
                CompImage = HelperPictures[2];
            }

            return;
        }

        //ヘルパーモードじゃないとき
        //初回起動時何も選ばれてないとき
        if(variety == 0)
        {
            if(page == 0)
            {
                ShowImage.texture = ClearPictures[0];
                return;
            }
        }

        //BOX
        if (variety == 0)
        {
            //プレゼント
            if (page == 2)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 箱
                else if (count == 2)
                {
                    ShowImage.texture = Boxes[0];
                    CompImage = CompBoxes[0];
                }
                //4つ目 プレゼント
                else if (count == 3)
                {
                    ShowImage.texture = Boxes[2];
                    CompImage = CompBoxes[2];
                }
            }

            //宝箱
            else if (page == 4)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 箱
                else if (count == 2)
                {
                    ShowImage.texture = Boxes[0];
                    CompImage = CompBoxes[0];
                }
                //4つ目 お金
                else if (count == 3)
                {
                    ShowImage.texture = Boxes[1];
                    CompImage = CompBoxes[1];
                }
            }
        }
        //PLANT
        else if (variety == 1)
        {
            //木
            if (page == 2)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 木
                else if (count == 3)
                {
                    ShowImage.texture = Plants[8];
                    CompImage = CompPlants[8];
                }
            }
            //クリスマスツリー
            else if (page == 4)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 木
                else if (count == 3)
                {
                    ShowImage.texture = Plants[0];
                    CompImage = CompPlants[0];
                }
            }
            //やしの木
            else if (page == 6)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 ヤシの木
                else if (count == 3)
                {
                    ShowImage.texture = Plants[4];
                    CompImage = CompPlants[4];
                }
            }
            //雪が積もった木
            else if (page == 8)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 雪が積もった木
                else if (count == 3)
                {
                    ShowImage.texture = Plants[6];
                    CompImage = CompPlants[6];
                }
            }
            //雪だるま
            else if (page == 10)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 雪だるま
                else if (count == 3)
                {
                    ShowImage.texture = Plants[7];
                    CompImage = CompPlants[7];
                }
            }
            //花
            else if (page == 12)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 花
                else if (count == 3)
                {
                    ShowImage.texture = Plants[1];
                    CompImage = CompPlants[1];
                }
            }
            //雪だるま
            else if (page == 14)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 雪だるま
                else if (count == 3)
                {
                    ShowImage.texture = Plants[7];
                    CompImage = CompPlants[7];
                }
            }
            //ひよこ
            else if (page == 16)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 ひよこ
                else if (count == 3)
                {
                    ShowImage.texture = Plants[2];
                    CompImage = CompPlants[2];
                }
            }
            //きのこ
            else if (page == 18)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 植物
                else if (count == 2)
                {
                    ShowImage.texture = Plants[5];
                    CompImage = CompPlants[5];
                }
                //4つ目 きのこ
                else if (count == 3)
                {
                    ShowImage.texture = Plants[3];
                    CompImage = CompPlants[3];
                }
            }
        }
        //TOOL
        else if (variety == 2)
        {
            //ブランコ
            if (page == 2)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 ブランコ
                else if (count == 3)
                {
                    ShowImage.texture = Tools[1];
                    CompImage = CompTools[1];
                }
            }
            //柵
            else if (page == 4)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 柵
                else if (count == 3)
                {
                    ShowImage.texture = Tools[5];
                    CompImage = CompTools[5];
                }
            }
            //ポスト
            else if (page == 6)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 ポスト
                else if (count == 3)
                {
                    ShowImage.texture = Tools[4];
                    CompImage = CompTools[4];
                }
            }
            //家
            else if (page == 8)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 家
                else if (count == 3)
                {
                    ShowImage.texture = Tools[2];
                    CompImage = CompTools[2];
                }
            }
            //ボート
            else if (page == 10)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 ボート
                else if (count == 3)
                {
                    ShowImage.texture = Tools[0];
                    CompImage = CompTools[0];
                }
            }
            //パラソル
            else if (page == 12)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 パラソル
                else if (count == 3)
                {
                    ShowImage.texture = Tools[3];
                    CompImage = CompTools[3];
                }
            }
            //サーフボード
            else if (page == 14)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 サーフボード
                else if (count == 3)
                {
                    ShowImage.texture = Tools[8];
                    CompImage = CompTools[8];
                }
            }
            //じょうろ
            else if (page == 16)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 じょうろ
                else if (count == 3)
                {
                    ShowImage.texture = Tools[10];
                    CompImage = CompTools[10];
                }
            }
            //サンタ帽子
            else if (page == 18)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 サンタ帽子
                else if (count == 3)
                {
                    ShowImage.texture = Tools[6];
                    CompImage = CompTools[6];
                }
            }
            //じょうろ
            else if (page == 20)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 じょうろ
                else if (count == 3)
                {
                    ShowImage.texture = Tools[10];
                    CompImage = CompTools[10];
                }
            }
            //そり
            else if (page == 22)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 置く
                else if (count == 1)
                {
                    ShowImage.texture = Operations[2];
                    CompImage = CompOperations[2];
                }
                //3つ目 道具
                else if (count == 2)
                {
                    ShowImage.texture = Tools[9];
                    CompImage = CompTools[9];
                }
                //4つ目 そり
                else if (count == 3)
                {
                    ShowImage.texture = Tools[7];
                    CompImage = CompTools[7];
                }
            }
        }
        //WEATHER
        else if (variety == 3)
        {
            //はれ
            if (page == 2)
            {
                maxdraw = 3;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 天気
                else if (count == 1)
                {
                    ShowImage.texture = Operations[0];
                    CompImage = CompOperations[0];
                }
                //3つ目 はれ
                else if (count == 2)
                {
                    ShowImage.texture = Weathers[2];
                    CompImage = CompWeathers[2];
                }
            }
            //あめ
            if (page == 4)
            {
                maxdraw = 3;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 天気
                else if (count == 1)
                {
                    ShowImage.texture = Operations[0];
                    CompImage = CompOperations[0];
                }
                //3つ目 はれ
                else if (count == 2)
                {
                    ShowImage.texture = Weathers[0];
                    CompImage = CompWeathers[0];
                }
            }
            //ゆき
            if (page == 6)
            {
                maxdraw = 3;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 天気
                else if (count == 1)
                {
                    ShowImage.texture = Operations[0];
                    CompImage = CompOperations[0];
                }
                //3つ目 ゆき
                else if (count == 2)
                {
                    ShowImage.texture = Weathers[1];
                    CompImage = CompWeathers[1];
                }
            }
        }
    }

    public void MagicWordsChgOC(int variety, int page)
    {
        //描いた枚数 
        int count = sc.capcounter;

        //ヘルパーモードの時
        if (sm.HelperMode)
        {
            maxdraw = 3;
            //1つ目 魔法陣
            if (count == 0)
            {
                ShowImage.texture = HelperPictures[0];
                CompImage = HelperPictures[0];
            }
            //2つ目 置く
            else if (count == 1)
            {
                ShowImage.texture = HelperPictures[1];
                CompImage = HelperPictures[1];
            }
            //3つ目 雪だるま
            else if (count == 2)
            {
                ShowImage.texture = HelperPictures[2];
                CompImage = HelperPictures[2];
            }

            return;
        }

        //ヘルパーモードじゃないとき
        //初回起動時何も選ばれてないとき
        if (variety == 0)
        {
            if (page == 0)
            {
                ShowImage.texture = ClearPictures[0];
                return;
            }
        }

        //BOX
        if (variety == 0)
        {
            //プレゼント
            if (page == 2)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 プレゼント
                else if (count == 1)
                {
                    ShowImage.texture = Boxes[2];
                    CompImage = CompBoxes[2];
                }
            }

            //宝箱
            else if (page == 4)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 お金
                else if (count == 1)
                {
                    ShowImage.texture = Boxes[1];
                    CompImage = CompBoxes[1];
                }
            }
        }
        //PLANT
        else if (variety == 1)
        {
            //木
            if (page == 2)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 木
                else if (count == 2)
                {
                    ShowImage.texture = Plants[8];
                    CompImage = CompPlants[8];
                }
            }
            //クリスマスツリー
            else if (page == 4)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 木
                else if (count == 1)
                {
                    ShowImage.texture = Plants[0];
                    CompImage = CompPlants[0];
                }
            }
            //やしの木
            else if (page == 6)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ヤシの木
                else if (count == 1)
                {
                    ShowImage.texture = Plants[4];
                    CompImage = CompPlants[4];
                }
            }
            //雪が積もった木
            else if (page == 8)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 雪が積もった木
                else if (count == 1)
                {
                    ShowImage.texture = Plants[6];
                    CompImage = CompPlants[6];
                }
            }
            //雪だるま
            else if (page == 10)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 雪だるま
                else if (count == 1)
                {
                    ShowImage.texture = Plants[7];
                    CompImage = CompPlants[7];
                }
            }
            //花
            else if (page == 12)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 花
                else if (count == 1)
                {
                    ShowImage.texture = Plants[1];
                    CompImage = CompPlants[1];
                }
            }
            //雪だるま
            else if (page == 14)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 雪だるま
                else if (count == 1)
                {
                    ShowImage.texture = Plants[7];
                    CompImage = CompPlants[7];
                }
            }
            //ひよこ
            else if (page == 16)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ひよこ
                else if (count == 1)
                {
                    ShowImage.texture = Plants[2];
                    CompImage = CompPlants[2];
                }
            }
            //きのこ
            else if (page == 18)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 きのこ
                else if (count == 1)
                {
                    ShowImage.texture = Plants[3];
                    CompImage = CompPlants[3];
                }
            }
        }
        //TOOL
        else if (variety == 2)
        {
            //ブランコ
            if (page == 2)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ブランコ
                else if (count == 1)
                {
                    ShowImage.texture = Tools[1];
                    CompImage = CompTools[1];
                }
            }
            //柵
            else if (page == 4)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 柵
                else if (count == 1)
                {
                    ShowImage.texture = Tools[5];
                    CompImage = CompTools[5];
                }
            }
            //ポスト
            else if (page == 6)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ポスト
                else if (count == 1)
                {
                    ShowImage.texture = Tools[4];
                    CompImage = CompTools[4];
                }
            }
            //家
            else if (page == 8)
            {
                maxdraw = 4;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 家
                else if (count == 1)
                {
                    ShowImage.texture = Tools[2];
                    CompImage = CompTools[2];
                }
            }
            //ボート
            else if (page == 10)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ボート
                else if (count == 1)
                {
                    ShowImage.texture = Tools[0];
                    CompImage = CompTools[0];
                }
            }
            //パラソル
            else if (page == 12)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 パラソル
                else if (count == 1)
                {
                    ShowImage.texture = Tools[3];
                    CompImage = CompTools[3];
                }
            }
            //サーフボード
            else if (page == 14)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 サーフボード
                else if (count == 1)
                {
                    ShowImage.texture = Tools[8];
                    CompImage = CompTools[8];
                }
            }
            //じょうろ
            else if (page == 16)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 じょうろ
                else if (count == 1)
                {
                    ShowImage.texture = Tools[10];
                    CompImage = CompTools[10];
                }
            }
            //サンタ帽子
            else if (page == 18)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 サンタ帽子
                else if (count == 1)
                {
                    ShowImage.texture = Tools[6];
                    CompImage = CompTools[6];
                }
            }
            //じょうろ
            else if (page == 20)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 じょうろ
                else if (count == 1)
                {
                    ShowImage.texture = Tools[10];
                    CompImage = CompTools[10];
                }
            }
            //そり
            else if (page == 22)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 そり
                else if (count == 1)
                {
                    ShowImage.texture = Tools[7];
                    CompImage = CompTools[7];
                }
            }
        }
        //WEATHER
        else if (variety == 3)
        {
            //はれ
            if (page == 2)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 はれ
                else if (count == 1)
                {
                    ShowImage.texture = Weathers[2];
                    CompImage = CompWeathers[2];
                }
            }
            //あめ
            if (page == 4)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 はれ
                else if (count == 1)
                {
                    ShowImage.texture = Weathers[0];
                    CompImage = CompWeathers[0];
                }
            }
            //ゆき
            if (page == 6)
            {
                maxdraw = 2;
                //1つ目 魔法陣
                if (count == 0)
                {
                    ShowImage.texture = ClearPictures[0];
                }
                //2つ目 ゆき
                else if (count == 1)
                {
                    ShowImage.texture = Weathers[1];
                    CompImage = CompWeathers[1];
                }
            }
        }
    }

    //選択された本を取得
    public int GetSelectedBookNum()
    {
        return (int)bs;
    }

    //選択された本のページ番号を取得
    public int GetBookPage()
    {
        int page = 0;
        page = Books[GetSelectedBookNum()].GetComponent<Book>().currentPage;
        return page;
    }

    IEnumerator PlaySphereParticle()
    {
        yield return new WaitForSeconds(1f);
        SphereParticle.Play();
    }

    public void ChgBookSel(int num)
    {
        switch (num)
        {
            case 0:
                bs = BookSel.BOXES;
                break;
            case 1:
                bs = BookSel.PLANTS;
                break;
            case 2:
                bs = BookSel.TOOLS;
                break;
            case 3:
                bs = BookSel.WEATHER;
                break;
        }
        
    }
}
