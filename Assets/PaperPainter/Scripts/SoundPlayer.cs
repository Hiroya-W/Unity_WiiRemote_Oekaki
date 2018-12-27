using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public StatusManager sm;

    public AudioSource[] Source;
    AudioSource Painting;
    AudioSource Singing;
    AudioSource Page;

	// Use this for initialization
	void Start () {
        Painting = Source[0];
        Singing = Source[1];
        Page = Source[2];
	}

    private void Update()
    {
        //本は閉じている状態
        if (!sm.BookCh)
        {
            //マウス入力があれば
            if (Input.GetMouseButton(0))
            {
                //再生されていないとき
                if (!Painting.isPlaying)
                {
                    PlayPainting();
                }
            }
            else
            {
                StopPainting();
            }
        }
        else
        {
            StopPainting();
        }
    }

    public void PlayPainting()
    {
        Painting.loop = true;
        Painting.Play();
    }

    public void StopPainting()
    {
        Painting.loop = false;
    }

    public void PlaySinging()
    {
        Singing.Play();
    }

    public void PlayPage()
    {
        Page.Play();
    }
}
