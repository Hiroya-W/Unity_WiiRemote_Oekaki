using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrimingScript : MonoBehaviour {

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
        Texture2D dst;

        //トリミングした領域のピクセル配列を取得
        Color[] pix = src.GetPixels(x, y, width, height);

        //出力先のテクスチャに割り当て
        dst = new Texture2D(width, height);
        dst.SetPixels(pix);
        dst.Apply();

        return dst;
    }
}
