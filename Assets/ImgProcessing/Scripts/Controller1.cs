using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity;
//using UnityEditor;
using System.IO;

public class Controller1 : MonoBehaviour {

    public SphereParticleCtl SpherePc;

    //RawImage のリスト
    public List<RawImage> RawImageList = new List<RawImage>();

    //認識した画像の番号配列　配列数は4
    public int[] DetectImgNum;

    //生成するRawimageのプレハブ
    public RawImage rawimgpre;

    //生成するRawimageの親オブジェクト
    public Canvas rawimgcanvas;

    //比較用画像の読み込み
    public MagicWordsCtl mwc;

    // OLD 下絵(比較絵の用意)
    public RawImage ShowImage;

    //ScreenCaptureスクリプト
    public ScreenCapture ScCap;

    //StatusManager
    public StatusManager sm;

    //一致率表示用テキスト
    public GameObject RateText;

    //同時に表示する画像Texture
    public Texture2D[] RatePictures;

    //表示するためのRawImage
    public GameObject RateRawImage;

    //トリミングする範囲指定
    [System.Serializable]
    public struct Area
    {
        public int x;
        public int y;
        public int w;
        public int h;
    }
    public Area TriArea;
    //x 634 y 0 w 880 h 880

    //テクスチャ適応画像
    public RawImage LoadImage;
    public RawImage TrimImage;
    public RawImage GrayImage;
    public RawImage BinaryImage;

    //読み込んだ画像
    Texture2D LoadTexture;

    //トリミング画像
    Texture2D TrimTexture;

    //グレー画像
    Texture2D GrayTexture;

    //2値
    Texture2D BinaryTexture;

    //コルーチンの確保
    IEnumerator Sing;
    IEnumerator NotSing;
    IEnumerator WriteRate;
    IEnumerator ShowRate;
    private void Start()
    {
        RateText.gameObject.GetComponent<Text>().text = "";
        Sing = Singwaiting();
        NotSing = NotSingwaiting();
        //一致率表示
        WriteRate = WriteRateText();
        ShowRate = ShowRatePicture();
    }

    // Use this for initialization
    public void DrawImg () {

        //画像読み込み
        Debug.Log("画像を読み込みます");
        string Path = "/ScreenShots/ss" + ScCap.capcounter.ToString() + ".png";
        //LoadTexture = ImageLoader(Path,LoadTexture);
        LoadTexture = ImageLoader(Path);
        //描画するRawImageにTexture2Dを設定
        LoadImage.texture = LoadTexture;

        //テクスチャの切り取り
        Debug.Log("クリッピングを行います");
        TrimTexture = TrimingTexture(LoadTexture, TriArea.x, TriArea.y, TriArea.w, TriArea.h);
        //描画するRawImageにTexture2Dを設定
        TrimImage.texture = TrimTexture;

        //グレー
        Debug.Log("グレー変換を行います");
        GrayTexture = GrayConvert(TrimTexture);
        //描画するRawImageにTexture2Dを設定
        GrayImage.texture = GrayTexture;

        //2値化
        Debug.Log("2値化を行います");
        BinaryTexture = BinaryConvert(GrayTexture);
        //描画するRawImageにTexture2Dを設定
        BinaryImage.texture = BinaryTexture;

        //色を取り出す
        //Black(0,0,0,255), White(255,255,255,255)
        Debug.Log("色を取り出します");
        Color32[] BinaryColor = new Color32[BinaryTexture.height * BinaryTexture.width];
        BinaryColor = BinaryTexture.GetPixels32();

        int maxcount = 0;
        int count = 0;
        float rate = 0;

        //ヘルパーモードの時
        if (sm.HelperMode)
        {
            //画像一致検出
            Debug.Log("画像一致検出を行います");

            //比較元のテクスチャ
            //Texture2D CompTexture = ShowImage.texture as Texture2D;
            Texture2D CompTexture = mwc.CompImage;

            CompTexture = GrayConvert(CompTexture);
            CompTexture = BinaryConvert(CompTexture);
            GrayImage.texture = CompTexture;

            //比較元の色
            Color32[] CompColor = new Color32[CompTexture.height * CompTexture.width];
            CompColor = CompTexture.GetPixels32();

            //Debug.Log("CompTexture:" + CompTexture.height + " " + CompTexture.width);
            //Debug.Log("BinaryTexture:" + BinaryTexture.height + " " + BinaryTexture.width);

            //全ピクセル走査
            for (int i = 0; i < CompTexture.height * CompTexture.width; i++)
            {
                //描いた絵が黒のピクセルだった時
                if (CompColor[i].r == 0)
                {
                    maxcount++;
                    //比較元と一致したら
                    if (BinaryColor[i].r == 0)
                    {
                        count++;
                    }
                }
            }
        }
        else
        {
            //一枚目は一致検出せずに表示させる
            if (ScCap.capcounter == 1)
            {
                //何か書かれていればOK
                //全ピクセル走査
                for (int i = 0; i < BinaryColor.Length; i++)
                {
                    //描いた絵が黒のピクセルだった時
                    if (BinaryColor[i].r == 0)
                    {
                        maxcount++;
                    }
                }

                //一定以上描かれていたら
                if(maxcount > 10000)
                {
                    //一致率100%にする
                    Debug.Log("一枚目を表示します");
                    count = maxcount;
                }
                else
                {
                    //一致率0%にする
                    Debug.Log("一枚目を表示しません");
                    count = 0;
                }
            }
            //二枚目からは一致検出させる
            else
            {
                //下絵が存在すれば
                if (!(mwc.CompImage == null))
                {
                    //画像一致検出
                    Debug.Log("画像一致検出を行います");

                    //比較元のテクスチャ
                    //Texture2D CompTexture = ShowImage.texture as Texture2D;
                    Texture2D CompTexture = mwc.CompImage;

                    CompTexture = GrayConvert(CompTexture);
                    CompTexture = BinaryConvert(CompTexture);
                    GrayImage.texture = CompTexture;

                    //比較元の色
                    Color32[] CompColor = new Color32[CompTexture.height * CompTexture.width];
                    CompColor = CompTexture.GetPixels32();

                    //Debug.Log("CompTexture:" + CompTexture.height + " " + CompTexture.width);
                    //Debug.Log("BinaryTexture:" + BinaryTexture.height + " " + BinaryTexture.width);

                    //全ピクセル走査
                    for (int i = 0; i < CompTexture.height * CompTexture.width; i++)
                    {
                        //描いた絵が黒のピクセルだった時
                        if (BinaryColor[i].r == 0)
                        {
                            maxcount++;
                            //比較元と一致したら
                            if (CompColor[i].r == 0)
                            {
                                count++;
                            }
                        }
                    }

                    if(maxcount < 90000)
                    {
                        count = Mathf.FloorToInt(maxcount * 0.3f);
                    }
                }
                //下絵がなかった時
                else
                {
                    count = 0;
                    maxcount = 1;
                }                
            }
        }

        Debug.Log("maxcount : " + maxcount.ToString());
        //一致率
        rate = (float)count / maxcount;
        //StatusManagerの一致率で補完
        sm.rate = rate;
        Debug.Log("一致率は" + rate * 100 + "%です");
        //一致率が50%以下だったら
        if(0.5f >= rate)
        {
            Debug.Log("画像は表示させません");
            //写真の保存を取り消す
            ScCap.capcounter = ScCap.capcounter - 1;
        }
        else
        {
            //RawImage作成
            Debug.Log("画像を表示します");
            RawImage rawimg = Instantiate(rawimgpre, rawimgcanvas.transform);

            //RawImageにテクスチャを適応
            rawimg.texture = TrimTexture;

            //RawImageをListに追加
            RawImageList.Add(rawimg);

            //RawImageの移動
            RectTransform rawrect = rawimg.GetComponent<RectTransform>();

            float x = rawrect.localPosition.x;
            float y = rawrect.localPosition.y - 80 * (ScCap.capcounter - 1);
            float z = rawrect.localPosition.z;
            Vector3 pot = new Vector3(x, y, z);

            rawrect.localPosition = pot;
            Debug.Log("画像を保存し表示が完了しました");
            
        }

        /*
        for (int Compimgnum = 0; Compimgnum < 9; Compimgnum++)
        {
            int count = 0;
            //画像読み込み
            string Path1 = "/CompareImage/ss" + Compimgnum.ToString() + ".png";
            Texture2D CompTexture = ImageLoader(Path1);
            //色読み込み
            Color32[] CompColor = new Color32[CompTexture.height * CompTexture.width];
            CompColor = CompTexture.GetPixels32();

            //全ピクセル操作
            for (int index = 0; index < CompTexture.height * CompTexture.width; index++)
            {
                //二値化画像で黒はR=G=B=0
                //R 0
                if((BinaryColor[index].r == CompColor[index].r) && (CompColor[index].r == 0))
                {
                    //一致した黒色ピクセル数
                    count++;
                }
            }
            Debug.Log(Compimgnum + " : " + count);
            //ピクセル操作が終わったら比較
            if(maxcount < count)
            {
                maxcount = count;
                maxnum = Compimgnum;
            }

        }*/
        //Debug.Log("一致した画像番号は" + maxnum + "です");
        //格納
        //DetectImgNum[ScCap.capcounter - 1] = maxnum;

        //終了
        isRunning = false;

        ShowImage.color = new Color(ShowImage.color.r, ShowImage.color.g, ShowImage.color.b, 0.3f);
        //パーティクルを表示
        //SpherePc.Particleplay();
        StartCoroutine(SpherePc.Particleplaydelay());

        //一致率表示
        StopCoroutine(WriteRate);
        StopCoroutine(ShowRate);

        WriteRate = WriteRateText();
        StartCoroutine(WriteRate);
        ShowRate = ShowRatePicture();
        StartCoroutine(ShowRate);

    }

    public bool isRunning;
    public bool isRunning1;
    public bool isRunning2;

    // Update is called once per frame
    void LateUpdate () {
        if (!isRunning)
        {
            if (ScCap.saveflag)
            {
                isRunning = true;
                DrawImg();
                //ScCap.saveflag = false;
                StartCoroutine(DelaySaveflagchg());
            }
        }


        //一枚以上書かれていた時
        if (ScCap.capcounter != 0)
        {
            //詠唱待ちの時
            if (sm.Singwait)
            {
                //NotSingwaitingが動作中なら
                if (isRunning2)
                {
                    //停止させる
                    StopCoroutine(NotSing);
                    isRunning2 = false;
                }
                //Singwaitingが動作していなければ
                if (!isRunning1)
                {
                    //動作させる
                    isRunning1 = true;
                    Sing = Singwaiting();
                    StartCoroutine(Sing);
                }
            }
            //詠唱待ちじゃないとき
            else
            {
                //Singwaitingが動作中なら
                if (isRunning1)
                {
                    StopCoroutine(Sing);
                    isRunning1 = false;
                }
                //NotSingwaitingが動作していなければ
                if (!isRunning2)
                {
                    //動作させる
                    isRunning2 = true;
                    NotSing = NotSingwaiting();
                    StartCoroutine(NotSing);
                }
            }
        }
    }

    //元の座標 x-290.7 y121.8 z0
    //移動座標1 x-270 y0 z0
    //移動座標2 x-130 y0 z0   x + 140する
    IEnumerator Singwaiting()
    {
        while(true)
        {
            float error = 0;
            for (int i = 0; i < RawImageList.Count; i++)
            {
                //描いた絵たちを移動させる
                RawImage rawimg = RawImageList[i];

                //RawImageの移動
                RectTransform rawrect = rawimg.GetComponent<RectTransform>();

                float x = -270 + i * 140;
                float y = 0;
                float z = 0;

                float width = 300f;
                float height = 300f;

                rawrect.sizeDelta = new Vector2(width, height);
                Vector3 pot = new Vector3(x, y, z);
                rawrect.localPosition = Vector3.Lerp(rawrect.localPosition, pot, 2 * Time.deltaTime);
                error += Mathf.Abs(rawrect.localPosition.x - -270);
            }

            //すべての誤差が小さくなれば
            if(error < 0.4f)
            {
                //ループを抜ける
                break;
            }
            yield return null;
        }
        //while (Mathf.Abs(RawImageList[0].GetComponent<RectTransform>().localPosition.x - -270f) > 0.1f);
        isRunning1 = false;
    }

    //元の座標 x-290.7 y121.8 z0
    IEnumerator NotSingwaiting()
    {
        while (true)
        {
            //Debug.Log("元に戻します");
            float error = 0;
            for (int i = 0; i < RawImageList.Count; i++)
            {
                //描いた絵たちを移動させる
                RawImage rawimg = RawImageList[i];

                //RawImageの移動
                RectTransform rawrect = rawimg.GetComponent<RectTransform>();

                float x = -290.7f;
                float y = 121.8f - 80 * i;
                float z = 0;

                float width = 200f;
                float height = 200f;

                rawrect.sizeDelta = new Vector2(width, height);
                Vector3 pot = new Vector3(x, y, z);
                rawrect.localPosition = Vector3.Lerp(rawrect.localPosition, pot, 2 * Time.deltaTime);
                error += Mathf.Abs(rawrect.localPosition.x - -290.7f);
            }

            //すべての誤差が小さくなれば
            if (error < 0.4f)
            {
                //ループを抜ける
                break;
            }
            yield return null;
        }

        //while (Mathf.Abs(RawImageList[0].GetComponent<RectTransform>().localPosition.x - -290.7f) > 0.1f);
        isRunning2 = false;
    }

    IEnumerator DelaySaveflagchg()
    {
        yield return null;
        ScCap.saveflag = false;
    }

    //一番最後に書いたやつを消す
    public void LastImageDelete()
    {
        //一枚以上書いていたら
        if(ScCap.capcounter > 0)
        {
            RawImage rawimg = RawImageList[ScCap.capcounter - 1];
            RawImageList.RemoveAt(ScCap.capcounter - 1);
            //削除
            Destroy(rawimg);
            //カウント - 1
            ScCap.capcounter -= 1;
        }
        else
        {
            //Debug.Log("なにも書かれていません ScCapcount = " + ScCap.capcounter.ToString());
            Debug.Log("なにも書かれていません");
        }
    }

    Texture2D ImageLoader(string Path)
    {
        Debug.Log("ImageLoaderの実行");
        Texture2D texture = null;
        if (LoadImage)
        {

            Mat LoadMat = Imgcodecs.imread(Application.dataPath + Path);

            if (LoadMat != null)
            {
                if (!LoadMat.empty())
                {
                    //Color32の作成
                    Color32[] color = new Color32[LoadMat.cols() * LoadMat.rows()];
                    if (color != null)
                    {
                        //Texture2Dを作成
                        texture = new Texture2D(LoadMat.cols(), LoadMat.rows());
                        //読み込んだMatをTexture2Dに変換
                        Utils.matToTexture2D(LoadMat, texture, color);
                    }
                }
            }
            else
            {
                Debug.LogError("画像が読み込ませんでした:ImageLoader");
            }
        }
        else
        {
            Debug.LogError("NotFound:rawImage");
        }
        return texture;
    }

    /// <summary>
    /// テクスチャ画像のトリミング処理(時間がかかる)
    /// </summary>
    /// <param name="src">元素材のテクスチャ</param>
    /// <param name="dst">出力先のテクスチャ</param>
    /// <param name="x">左上のx座標</param>
    /// <param name="y">左上のy座標</param>
    /// <param name="width">画像の横幅</param>
    /// <param name="height">画像の縦幅</param>
    public Texture2D TrimingTexture(Texture2D src, int x, int y, int width, int height)
    {
        Debug.Log("TrimingTextureの実行");
        Texture2D dst;

        //トリミングした領域のピクセル配列を取得
        Color[] pix = src.GetPixels(x, y, width, height);
        for (int i = 0; i < pix.Length; i++)
        {
            pix[i] = new Color(pix[i].b, pix[i].g, pix[i].r, pix[i].a);
        }

        //出力先のテクスチャに割り当て
        dst = new Texture2D(width, height);
        dst.SetPixels(pix);
        dst.Apply();

        return dst;
    }

    Texture2D GrayConvert(Texture2D LoadTexture)
    {
        Debug.Log("GrayConvertの実行");
        Texture2D texture_src = LoadTexture;
        if (texture_src == null)
        {
            Debug.Log("Not found");
            return null;
        }

        //テクスチャをMat画像へコピー
        Mat origin = new Mat(texture_src.height, texture_src.width, CvType.CV_8UC4);
        Utils.texture2DToMat(texture_src, origin);

        //グレイスケールMat
        Mat GrayMat = new Mat(origin.rows(), origin.cols(), CvType.CV_8UC1);
        //RGBA画像をグレイスケールに変換
        Imgproc.cvtColor(origin, GrayMat, Imgproc.COLOR_RGBA2GRAY);

        //グレイスケールのMatをテクスチャに変換
        Texture2D grayTexture = new Texture2D(GrayMat.cols(), GrayMat.rows(), TextureFormat.RGBA32, false);
        Utils.matToTexture2D(GrayMat, grayTexture);
        return grayTexture;
    }

    // Use this for initialization
    public Texture2D BinaryConvert(Texture2D loadTexture)
    {
        Debug.Log("BinaryConvertの実行");
        Mat imgMat = new Mat(loadTexture.height, loadTexture.width, CvType.CV_8UC1);

        Utils.texture2DToMat(loadTexture, imgMat);
        //Debug.Log("*" + "imgMat.ToString() " + imgMat.ToString());

        Imgproc.threshold(imgMat, imgMat, 0, 255, Imgproc.THRESH_BINARY | Imgproc.THRESH_OTSU);

        Texture2D texture = new Texture2D(imgMat.cols(), imgMat.rows(), TextureFormat.RGBA32, false);
        Utils.matToTexture2D(imgMat, texture);
        return texture;
    }
    
    //一致率表示
    IEnumerator WriteRateText()
    {
        Text Ratetxt = RateText.GetComponent<Text>();
        yield return new WaitForSeconds(0.5f);

        float r = Ratetxt.color.r;
        float g = Ratetxt.color.g;
        float b = Ratetxt.color.b;
        float a = Ratetxt.color.a;

        //透明
        Ratetxt.color = new Color(r, g, b, 0);
        //テキスト設定
        Ratetxt.text = "～" + (sm.rate*100).ToString("f1") + " [%]～";

        RateText.SetActive(true);

        float Loop = 100;


        for (int i = 0; i < Loop; i++)
        {
            Color c = new Color(r, g, b, 1f);
            Ratetxt.color = Color.Lerp(Ratetxt.color, c, (float)i/Loop);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < Loop; i++)
        {
            Color c = new Color(r, g, b, 0);
            Ratetxt.color = Color.Lerp(Ratetxt.color, c, (float)i / Loop);
            yield return null;
        }
        RateText.SetActive(false);
    }

    //一致率で表示する画像 Bad Good Excelent Lucky
    IEnumerator ShowRatePicture()
    {
        RawImage ri = RateRawImage.GetComponent<RawImage>();
        float rate = sm.rate * 100;

        //100%だったら
        if(rate == 100)
        {
            ri.texture = RatePictures[2];
        }
        //99.9だったら
        if(rate.ToString("f1") == "99.9")
        {
            ri.texture = RatePictures[3];
        }
        //90%以上だったら
        else if(rate > 90)
        {
            ri.texture = RatePictures[2];
        }
        //88.8%だったら
        else if (rate.ToString("f1") == "88.8")
        {
            ri.texture = RatePictures[3];
        }
        //77.7
        else if (rate.ToString("f1") == "77.7")
        {
            ri.texture = RatePictures[3];
        }
        //50%以上だったら
        else if (rate > 50)
        {
            ri.texture = RatePictures[1];
        }
        //50%以下だったら
        else
        {
            ri.texture = RatePictures[0];
        }
        yield return new WaitForSeconds(0.5f);

        float r = ri.color.r;
        float g = ri.color.g;
        float b = ri.color.b;
        float a = ri.color.a;

        //透明
        ri.color = new Color(r, g, b, 0);

        float Loop = 100;

        RateRawImage.SetActive(true);

        for (int i = 0; i < Loop; i++)
        {
            Color c = new Color(r, g, b, 1f);
            ri.color = Color.Lerp(ri.color, c, (float)i / Loop);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < Loop; i++)
        {
            Color c = new Color(r, g, b, 0);
            ri.color = Color.Lerp(ri.color, c, (float)i / Loop);
            yield return null;
        }
        RateRawImage.SetActive(false);

    }


}
