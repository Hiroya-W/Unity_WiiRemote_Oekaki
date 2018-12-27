using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;

public class Script1 : MonoBehaviour {

	public GrayScaleScript gs;

	[System.Serializable]
	public struct Area{
		public int x;
		public int y;
		public int w;
		public int h;
	}
	public Area TriArea;

	public RawImage rawImage;

	public RawImage rawImage1;

	private Mat originMat;
	private Texture2D texture;
	private Texture2D texture1;
	private Color32[] color;

	// Use this for initialization

	void Start () {
		if (rawImage) {
			//Mat画像をPathから読み込み
			originMat = Imgcodecs.imread (Application.dataPath + "/ScreenShots/ss0.png");
			if (originMat != null) {
				if (!originMat.empty ()) {
					//Color32の作成
					color = new Color32[originMat.cols () * originMat.rows ()];
					if (color != null) {
						//Texture2Dを作成
						texture = new Texture2D (originMat.cols (), originMat.rows ());
						//描画するRawImageにTexture2Dを設定
						rawImage.texture = texture;
					}
				}
			}
		} else {
			Debug.LogError("NotFound:rawImage");
		}
	
	}

	// Update is called once per frame
	void Update () {
		if (originMat != null) {
			if (!originMat.empty ()) {
				if (color != null) {
					if (texture != null) {

						/* 画像加工開始 */



						/* 画像加工終了 */

						//Matの編集内容をTexture2Dに反映
						Utils.matToTexture2D (originMat, texture, color);
					}
				}
			}
		}
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
    void cropTexture(Texture2D src, out Texture2D dst, int x, int y, int width, int height)
    {
        //トリミングした領域のピクセル配列を取得
        Color[] pix = src.GetPixels(x, y, width, height);

        //出力先のテクスチャに割り当て
        dst = new Texture2D(width, height);
        dst.SetPixels(pix);
        dst.Apply();
    }

	public void trimTexture(){
		//トリミングサイズはArea TriArea
		//Texture2Dを作成
		texture1 = new Texture2D (TriArea.w,TriArea.h);
		cropTexture(texture,out texture1,TriArea.x,TriArea.y,TriArea.w,TriArea.h);
		//描画するRawImageにTexture2Dを設定
		rawImage1.texture = texture1;
	}
}
