using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderPicture : MonoBehaviour {

    public RawImage ShowImage;
    public int Loop;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    bool isrunning;
    void Update () {
        if (!isrunning)
        {
            isrunning = true;
            StartCoroutine(MagicCircleCtl());
        }
    }

    IEnumerator MagicCircleCtl()
    {
        float r = ShowImage.color.r;
        float g = ShowImage.color.g;
        float b = ShowImage.color.b;
        float a = ShowImage.color.a;

        while (true)
        {
            for (int i = 0; i < Loop; i++)
            {
                Color c = new Color(r, g, b, 0.1f);
                ShowImage.color = Color.Lerp(ShowImage.color, c, speed * Time.deltaTime);
                yield return null;
            }

            for (int i = 0; i < Loop; i++)
            {
                Color c = new Color(r, g, b, 0.3f);
                ShowImage.color = Color.Lerp(ShowImage.color, c, speed * Time.deltaTime);
                yield return null;
            }
        }
    }

}
