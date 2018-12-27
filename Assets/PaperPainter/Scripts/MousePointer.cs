using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour {

    public BookController bc;
    public StatusManager sm;

    public Texture2D[] cursorTexture;
    public GameObject DrawCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public ParticleSystem Star;

    private int CursorNum;

    private void Start()
    {
        CursorNum = 7;
    }

    void Update()
    {
        /*
        if (!sm.BookCh)
        {
            if (Input.GetMouseButton(0))
            {
                //Cursor.visible = false;
                //DrawCursor.SetActive(true);
            }
            else
            {
                //Cursor.visible = true;
                //DrawCursor.SetActive(false);
                //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
        }
        else
        {
            //Cursor.visible = true;
            //DrawCursor.SetActive(false);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }*/

        Cursor.SetCursor(cursorTexture[CursorNum], hotSpot, cursorMode);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8.66f;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        objPos.z = 0;
        Star.transform.position = objPos;

    }

    public void Counter()
    {
        if(CursorNum == cursorTexture.Length-1)
        {
            CursorNum = 0;
        }
        else
        {
            CursorNum += 1;
        }        
    }
}
