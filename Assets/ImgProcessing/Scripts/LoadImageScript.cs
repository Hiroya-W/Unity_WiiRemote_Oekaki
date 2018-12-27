using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCVForUnity;
using System;

public class LoadImageScript : MonoBehaviour {

    public Mat LoadImageOutMat(String Path)
    {
        //Mat画像をPathから読み込み
        //loadMatに画像を読み込む
        Mat loadMat = Imgcodecs.imread(Application.dataPath + Path);
        return loadMat;
    }

    
    public void LoadImageOutTexture(String Path, out Mat loadMat, out Color32[] color_out, out Texture2D texture_out)
    {
        //Mat画像をPathから読み込み
        //loadMatに画像を読み込む
        loadMat = Imgcodecs.imread(Application.dataPath + Path);

        //テクスチャ
        Texture2D texture = null;
        Color32[] color = null;
        if (loadMat != null)
        {
            if (!loadMat.empty())
            {
                //Color32の作成
                color = new Color32[loadMat.cols() * loadMat.rows()];
                if (color != null)
                {
                    //Texture2Dを作成
                    texture = new Texture2D(loadMat.cols(), loadMat.rows());
                }
            }
        }
        else
        {
            Debug.Log("画像が読み込めませんでした");
        }
        //Matの編集内容をTexture2Dに反映
        Utils.matToTexture2D(loadMat, texture, color);

        texture_out = texture;
        color_out = color;
    }
    
}
