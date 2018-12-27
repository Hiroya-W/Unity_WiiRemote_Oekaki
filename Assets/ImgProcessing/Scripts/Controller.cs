using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity;

public class Controller : MonoBehaviour {

    //スクリプト参照
    public LoadImageScript loadImageScript;
    public TrimingScript triScript;
    public GrayScaleScript grayScript;
    public BinaryThresholdScript binaryScript;

    //テクスチャ適応画像
    public RawImage LoadImage;
    public RawImage TrimImage;
    public RawImage GrayImage;
    public RawImage BinaryImage;

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

    //ロード画像
    private Texture2D Loadtexture;
    private Color32[] LoadColor;
    private Mat LoadMat;

    //グレー画像
    private Texture2D Graytexture;
    private Mat GrayMat;

    private void Start()
    {
        //テクスチャの読み込み
        //Texture2D Loadtexture = loadImageScript.LoadImageOutTexture("/ScreenShots/ss0.png");

        loadImageScript.LoadImageOutTexture("/ScreenShots/ss0.png", out LoadMat, out LoadColor, out Loadtexture);

        //Matの編集内容をTexture2Dに反映
        Utils.matToTexture2D(LoadMat, Loadtexture, LoadColor);

        //描画するRawImageにTexture2Dを設定
        LoadImage.texture = Loadtexture;

        //テクスチャの切り取り
        Texture2D Trimtexture = triScript.TrimingTexture(Loadtexture, TriArea.x, TriArea.y, TriArea.w, TriArea.h);

        //切り取ったテクスチャのグレー変換
        grayScript.GrayScale(Trimtexture, out GrayMat, out Graytexture);

        //テクスチャの適応
        GrayImage.texture = Graytexture;

        //グレー画像から二値化画像の生成
        Texture2D Bintexture = binaryScript.Binary(Graytexture);

        //描画するRawImageにTexture2Dを設定
        //LoadImage.texture = Loadtexture;
        TrimImage.texture = Trimtexture;
        
        BinaryImage.texture = Bintexture;
    }

    private void Update()
    {
        //Matの編集内容をTexture2Dに反映
        Utils.matToTexture2D(LoadMat, Loadtexture, LoadColor);
    }
}
