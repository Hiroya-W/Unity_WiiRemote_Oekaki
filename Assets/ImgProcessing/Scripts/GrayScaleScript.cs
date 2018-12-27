using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;
 
public class GrayScaleScript : MonoBehaviour {

    // Use this for initialization
    public void GrayScale(Texture2D loadtexture, out Mat GrayMat, out Texture2D Graytexture) {
        //テクスチャ画像を読み込む
        //Texture2D texture_src = Resources.Load(texturePath) as Texture2D;
		Texture2D texture_src = loadtexture;
        Texture2D texture_out;

        if (texture_src == null){
			Debug.Log("Not found");
            GrayMat = null;
            Graytexture = null;
			return;
		}
			
        //テクスチャをMat画像へコピー
        Mat origin = new Mat(texture_src.height, texture_src.width, CvType.CV_8UC4);
        Utils.texture2DToMat(texture_src, origin);
 
        //グレイスケールMat
        Mat gray = new Mat(origin.rows(), origin.cols(), CvType.CV_8UC1);
        //RGBA画像をグレイスケールに変換
        Imgproc.cvtColor(origin, gray, Imgproc.COLOR_RGBA2GRAY);
 
        //グレイスケールのMatをテクスチャに変換
        texture_out = new Texture2D(gray.cols(), gray.rows(), TextureFormat.RGBA32, false);
        Utils.matToTexture2D(gray, texture_out);

        GrayMat = gray;
        Graytexture = texture_out;
    }
}