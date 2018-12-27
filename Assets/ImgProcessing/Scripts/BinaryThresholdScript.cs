using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;
 
public class BinaryThresholdScript : MonoBehaviour {
 
    /// <summary>
    /// 二値化の閾値
    /// </summary>
    [SerializeField, Range(0, 256)]
    int ThresBinary = 128;
 
    /// <summary>
    /// 閾値処理の反転を行うかどうか
    /// </summary>
    [SerializeField]
    bool binInv = false;
 
    // Use this for initialization
    public Texture2D Binary (Texture2D loadtexture)
    {
        //テクスチャ画像を読み込む
        //Texture2D texture_src = Resources.Load(texturePath) as Texture2D;
		Texture2D texture_src = loadtexture;
        Texture2D texture_out;

        //テクスチャをMat画像へコピー
        Mat origin = new Mat(texture_src.height, texture_src.width, CvType.CV_8UC4);
        Utils.texture2DToMat(texture_src, origin);
         
        //画像処理用Mat画像
        Mat mat_proc = new Mat(origin.rows(), origin.cols(), CvType.CV_8UC1);
        Imgproc.cvtColor(origin, mat_proc, Imgproc.COLOR_RGBA2GRAY);
  
        //------------------(今回追加した処理)--------------------
        //2値化処理(反転する場合は Imgproc.THRESH_BINARY_INVを使う)
        if (ThresBinary < 0 || ThresBinary > 255)
        {
            //GaussianCによる適応的閾値処理
            //adaptiveMethod: Imgproc.ADAPTIVE_THRESH_MEAN_C と分けて使う
            //thresholdType: Imgproc.THRESH_BINARY と分けて使う
            int type = (binInv) ? Imgproc.THRESH_BINARY_INV : Imgproc.THRESH_BINARY;
            Imgproc.adaptiveThreshold(mat_proc, mat_proc, 255, Imgproc.ADAPTIVE_THRESH_GAUSSIAN_C, type, 201, 11);
 
            //大津の手法による、単純2値化処理
            //Imgproc.THRESH_OTSUを指定すると、thresの値に関係なく自動で閾値を設定する
            //Imgproc.threshold(mat_proc, mat_proc, 0, 255, Imgproc.THRESH_BINARY_INV | Imgproc.THRESH_OTSU);
        }
        else
        {
            int type = (binInv) ? Imgproc.THRESH_BINARY_INV : Imgproc.THRESH_BINARY;
            Imgproc.threshold(mat_proc, mat_proc, ThresBinary, 255, type);
        }
        //------------------(今回追加した処理)--------------------
 
        //二値化処理したMatをテクスチャに変換
        texture_out = new Texture2D(mat_proc.cols(), mat_proc.rows(), TextureFormat.RGBA32, false);
        Utils.matToTexture2D(mat_proc, texture_out);

        //テクスチャの割り当て
        //GetComponent<Renderer>().material.mainTexture = texture_out;
        //thisraw.texture = texture_out;
        return texture_out;
    }
}