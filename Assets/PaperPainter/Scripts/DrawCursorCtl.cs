using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCursorCtl : MonoBehaviour {

    public ScreenCapture Sc;

    public StatusManager sm;

    public GameObject Cursor;
    public float speed = 2;
    //public bool drawflag;

    Vector2 center = new Vector2(1920/2,1080/2);
    float width = 800;
    float height = 800;

    public Vector3 CursorPoti;

    public float deg;

    
    private void OnMouseOver()
    {
                //カーソルが合ってる状態で　マウス入力があったとき
            if (Input.GetMouseButton(0))
            {
                sm.Drawflag = true;
            }
            else
            {
                if (sm.Drawflag)
                {
                    if (Sc.capcounter == 0)
                    {
                        DrawStarNumCounter();
                    }
                    else if (Sc.capcounter == 1)
                    {
                        DrawPutNumCounter();
                    }
                    else if (Sc.capcounter == 2)
                    {
                        DrawSnowBallNumCounter();
                    }

                }

                sm.Drawflag = false;
            }
            if (Sc.capcounter == 0)
            {
                DrawStar();
            }
            else if (Sc.capcounter == 1)
            {
                DrawPut();
            }
            else if (Sc.capcounter == 2)
            {
                DrawSnowBall();
            }
        
        
    }
    

    private void OnMouseExit()
    {
        sm.Drawflag = false;
    }

    public void DrawStarNumCounter()
    {
        if(DrawStarNum != 5)
        {
            DrawStarNum++;
        }
        else
        {
            DrawStarNum = 0;
        }
    }

    public void DrawPutNumCounter()
    {
        if (DrawPutNum != 4)
        {
            DrawPutNum++;
        }
        else
        {
            DrawPutNum = 0;
        }
    }

    public void DrawSnowBallNumCounter()
    {
        if (DrawSnowBallNum != 1)
        {
            DrawSnowBallNum++;
        }
        else
        {
            DrawSnowBallNum = 0;
        }
    }

    public int DrawStarNum;
    bool[] DrawStarflag = new bool[6];
    void DrawStar()
    {
        switch (DrawStarNum)
        {
            case 0:
                DrawStar0();
                break;
            case 1:
                DrawStar1();
                break;
            case 2:
                DrawStar2();
                break;
            case 3:
                DrawStar3();
                break;
            case 4:
                DrawStar4();
                break;
            case 5:
                DrawStar5();
                break;
        }
    }

    //置く
    public int DrawPutNum;
    bool[] DrawPutflag = new bool[6];
    void DrawPut()
    {
        switch (DrawPutNum)
        {
            case 0:
                DrawTriangle1();
                break;
            case 1:
                DrawTriangle2();
                break;
            case 2:
                DrawTriangle3();
                break;
            case 3:
                DrawPut1();
                break;
            case 4:
                DrawPut2();
                break;
        }
    }

    //置く
    public int DrawSnowBallNum;
    bool[] DrawSnowflag = new bool[2];
    void DrawSnowBall()
    {
        switch (DrawSnowBallNum)
        {
            case 0:
                Daruma1();
                break;
            case 1:
                Daruma2();
                break;
        }
    }

    //魔法陣
    //円を描く
    void DrawStar0()
    {
        float x, y, z = 8.66f;
        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[0])
        {
            DrawStarflag[0] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //0以外のフラグを下げる
                if(i!=0)
                    DrawStarflag[i] = false;
            }
            float rad = 90 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //角度計算用
            //中心を(0,0)とする
            inx = mousepoti.x - center.x;
            iny = mousepoti.y - center.y;

            //角度計算
            float rad = Mathf.Atan2(iny, inx);
            deg = rad * Mathf.Rad2Deg;

            //角度から円周の座標　マウス座標
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;            
        }
        CursorPoti = new Vector3(x, y, z);

        //マウス座標からワールド座標へ
        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }
    

    //星を描く
    void DrawStar1()
    {
        // 1 deg 90 
        // 2 deg -126
        // 3 deg 18
        // 4 deg 162
        // 5 deg -54

        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[1])
        {
            DrawStarflag[1] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //1以外のフラグを下げる
                if (i != 1)
                    DrawStarflag[i] = false;
            }
            float rad = 90 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            // y = 3.077683537 * x -2005.576196
            float rad1 = -126 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = 90 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            //x = (iny + 2005.576196f) / 3.077683537f;
            x = (iny - b) / a;
            y = iny;

            //if(!((225.3932023f < iny) && (iny < 949f)))
            if (!((y1 < iny) && (iny < y2)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }
        
        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;
        
        Cursor.transform.position = objPos;
    }

    void DrawStar2()
    {
        // 1 deg 90 
        // 2 deg -126
        // 3 deg 18
        // 4 deg 162
        // 5 deg -54

        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[2])
        {
            DrawStarflag[2] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //2以外のフラグを下げる
                if (i != 2)
                    DrawStarflag[i] = false;
            }
            float rad = -126 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = -126 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = 18 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = (iny - b) / a;
            y = iny;

            //移動可能範囲
            if (!((y1 < iny) && (iny < y2)))
            {
                //Debug.Log("Out of Movable Range" + y1.ToString() + " " + y2.ToString());
                return;
            }
        } 

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    void DrawStar3()
    {
        // 1 deg 90 
        // 2 deg -126
        // 3 deg 18
        // 4 deg 162
        // 5 deg -54

        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[3])
        {
            DrawStarflag[3] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //3以外のフラグを下げる
                if (i != 3)
                    DrawStarflag[i] = false;
            }
            float rad = 18 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = 162 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = 18 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = inx;
            y = y1;

            //移動可能範囲
            if (!((x1 < inx) && (inx < x2)))
            {
                //Debug.Log("Out of Movable Range" + x1.ToString() + " " + x2.ToString());
                return;
            }
        }
        
        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    void DrawStar4()
    {
        // 1 deg 90 
        // 2 deg -126
        // 3 deg 18
        // 4 deg 162
        // 5 deg -54

        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[4])
        {
            DrawStarflag[4] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //4以外のフラグを下げる
                if (i != 4)
                    DrawStarflag[i] = false;
            }
            float rad = 162 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = 162 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = -54 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = (iny - b) / a;
            y = iny;

            //移動可能範囲
            if (!((y2 < iny) && (iny < y1)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    void DrawStar5()
    {
        // 1 deg 90 
        // 2 deg -126
        // 3 deg 18
        // 4 deg 162
        // 5 deg -54

        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawStarflag[5])
        {
            DrawStarflag[5] = true;
            for (int i = 0; i < DrawStarflag.Length; i++)
            {
                //5以外のフラグを下げる
                if (i != 5)
                    DrawStarflag[i] = false;
            }
            float rad = -54 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = 90 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = -54 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = (iny - b) / a;
            y = iny;

            //移動可能範囲
            if (!((y2 < iny) && (iny < y1)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }
        
        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    //置く
    //三角形1
    void DrawTriangle1()
    {
        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawPutflag[0])
        {
            DrawPutflag[0] = true;
            for (int i = 0; i < DrawPutflag.Length; i++)
            {
                //0以外のフラグを下げる
                if (i != 0)
                    DrawPutflag[i] = false;
            }
            x = center.x;
            y = center.y;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = -120 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float x2 = center.x;
            float y2 = center.y;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = (iny - b) / a;
            y = iny;

            //移動可能範囲
            if (!((y1 < iny) && (iny < y2)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;

    }

    //三角形2
    void DrawTriangle2()
    {
        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawPutflag[1])
        {
            DrawPutflag[1] = true;
            for (int i = 0; i < DrawPutflag.Length; i++)
            {
                //1以外のフラグを下げる
                if (i != 1)
                    DrawPutflag[i] = false;
            }

            float rad = -120 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad = -120 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;

            float rad2 = -60 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = inx;
            y = y1;

            //移動可能範囲
            if (!((x1 < inx) && (inx < x2)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    //三角形3
    void DrawTriangle3()
    {
        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawPutflag[2])
        {
            DrawPutflag[2] = true;
            for (int i = 0; i < DrawPutflag.Length; i++)
            {
                //2以外のフラグを下げる
                if (i != 2)
                    DrawPutflag[i] = false;
            }

            float rad = -60 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float x1 = center.x;
            float y1 = center.y;

            float rad2 = -60 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = (iny - b) / a;
            y = iny;

            //移動可能範囲
            if (!((y2 < iny) && (iny < y1)))
            {
                //Debug.Log("Out of Movable Range");
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;

    }

    //ふた1
    void DrawPut1()
    {
        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawPutflag[3])
        {
            DrawPutflag[3] = true;
            for (int i = 0; i < DrawPutflag.Length; i++)
            {
                //3以外のフラグを下げる
                if (i != 3)
                    DrawPutflag[i] = false;
            }

            float rad = 18 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = 162 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = 18 * Mathf.Deg2Rad;
            float x2 = ((1 + Mathf.Cos(rad2)) / 2) * width + center.x - width / 2;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            float a = (y2 - y1) / (x2 - x1);
            float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = inx;
            y = y1;

            //移動可能範囲
            if (!((x1 < inx) && (inx < x2)))
            {
                //Debug.Log("Out of Movable Range" + x1.ToString() + " " + x2.ToString());
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    //ふた2
    void DrawPut2()
    {
        float x, y, z = 8.66f;

        float inx, iny;
        Vector2 mousepoti = Input.mousePosition;
        inx = mousepoti.x;
        iny = mousepoti.y;

        //初めて書く場合
        //座標の移動
        if (!DrawPutflag[4])
        {
            DrawPutflag[4] = true;
            for (int i = 0; i < DrawPutflag.Length; i++)
            {
                //4以外のフラグを下げる
                if (i != 4)
                    DrawPutflag[i] = false;
            }

            float rad = 90 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width + center.x - width / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height + center.y - height / 2;
        }
        else
        {
            //線分 y = a * x + b
            float rad1 = 90 * Mathf.Deg2Rad;
            float x1 = ((1 + Mathf.Cos(rad1)) / 2) * width + center.x - width / 2;
            float y1 = ((1 + Mathf.Sin(rad1)) / 2) * height + center.y - height / 2;

            float rad2 = 18 * Mathf.Deg2Rad;
            float x2 = x1;
            float y2 = ((1 + Mathf.Sin(rad2)) / 2) * height + center.y - height / 2;

            //float a = (y2 - y1) / (x2 - x1);
            //float b = y1 - a * x1;

            // x = (y - b) / a
            //Debug.Log("y = " + a.ToString() + " x * " + b.ToString());
            x = x1;
            y = iny;

            //移動可能範囲
            if (!((y2 < iny) && (iny < y1)))
            {
                //Debug.Log("Out of Movable Range" + x1.ToString() + " " + x2.ToString());
                return;
            }
        }

        CursorPoti = new Vector3(x, y, z);

        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    //雪だるま
    //したの丸
    void Daruma1()
    {
        float x, y, z = 8.66f;
        float inx, iny;
        float width1 = 500;
        float height1 = 500;
        float offset = 250;
        Vector2 mousepoti = Input.mousePosition;

        //初めて書く場合
        //座標の移動
        if (!DrawSnowflag[0])
        {
            DrawSnowflag[0] = true;
            for (int i = 0; i < DrawSnowflag.Length; i++)
            {
                //0以外のフラグを下げる
                if (i != 0)
                    DrawSnowflag[i] = false;
            }
            float rad = 90 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width1 + center.x - width1 / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height1 + center.y - height1 / 2 - offset;
        }
        else
        {
            //角度計算用
            //中心を(0,0)とする
            inx = mousepoti.x - center.x;
            iny = mousepoti.y - offset;

            //角度計算
            float rad = Mathf.Atan2(iny, inx);
            deg = rad * Mathf.Rad2Deg;

            //角度から円周の座標　マウス座標
            x = ((1 + Mathf.Cos(rad)) / 2) * width1 + center.x - width1 / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height1 + center.y - height1 / 2 - offset;
        }
        CursorPoti = new Vector3(x, y, z);

        //マウス座標からワールド座標へ
        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }

    //したの丸
    void Daruma2()
    {
        float x, y, z = 8.66f;
        float inx, iny;
        float width1 = 500;
        float height1 = 500;
        float offset = -250;
        Vector2 mousepoti = Input.mousePosition;

        //初めて書く場合
        //座標の移動
        if (!DrawSnowflag[0])
        {
            DrawSnowflag[0] = true;
            for (int i = 0; i < DrawSnowflag.Length; i++)
            {
                //0以外のフラグを下げる
                if (i != 0)
                    DrawSnowflag[i] = false;
            }
            float rad = 90 * Mathf.Deg2Rad;
            x = ((1 + Mathf.Cos(rad)) / 2) * width1 + center.x - width1 / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height1 + center.y - height1 / 2 - offset;
        }
        else
        {
            //角度計算用
            //中心を(0,0)とする
            inx = mousepoti.x - center.x;
            iny = mousepoti.y - center.x - offset;

            //角度計算
            float rad = Mathf.Atan2(iny, inx);
            deg = rad * Mathf.Rad2Deg;

            //角度から円周の座標　マウス座標
            x = ((1 + Mathf.Cos(rad)) / 2) * width1 + center.x - width1 / 2;
            y = ((1 + Mathf.Sin(rad)) / 2) * height1 + center.y - height1 / 2 - offset;
        }
        CursorPoti = new Vector3(x, y, z);

        //マウス座標からワールド座標へ
        Vector3 objPos = Camera.main.ScreenToWorldPoint(CursorPoti);
        objPos.z = 0;

        Cursor.transform.position = objPos;
    }
}
