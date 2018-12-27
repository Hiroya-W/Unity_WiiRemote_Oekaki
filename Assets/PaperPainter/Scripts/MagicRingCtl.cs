using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Es.InkPainter
{
    public class MagicRingCtl : MonoBehaviour
    {
        public GameObject ClearPanel;
        public GameObject Rings;
        //public GameObject Mask;
        public ScreenCapture sc;
        public StatusManager sm;

        //生成したObjectを持っておくためのList
        List<GameObject> list_ClearPanels = new List<GameObject>();

        //複雑さ
        //生成するパネルの数
        public int complexity;

        private void Update()
        {
            //ヘルパーモードじゃないとき
            if (!sm.HelperMode)
            {
                //クリアパネルが表示されていないとき
                if (!ClearPanel.activeInHierarchy)
                {
                    //表示する
                    ClearPanel.SetActive(true);
                    Rings.SetActive(true);
                }                
                //一枚目　まだ一枚も書かれていないとき
                if (sc.capcounter == 0)
                {
                    //パネルが用意されていれば
                    if (list_ClearPanels.Count != 0)
                    {
                        //Material material = ClearPanel.GetComponent<Material>();
                        InkCanvas ic = ClearPanel.GetComponent<InkCanvas>();
                        //RenderTexture rt = ic.GetPaintMainTexture(material.name);
                        RenderTexture rt = ic.GetPaintMainTexture("clear");

                        //リストで保持しているインスタンスに設定
                        for (int i = 0; i < list_ClearPanels.Count; i++)
                        {
                            InkCanvas ic1 = list_ClearPanels[i].GetComponent<InkCanvas>();
                            ic1.SetPaintMainTexture("clear", rt);
                        }
                    }
                    //パネルが用意されていなければ
                    else
                    {
                        //パネル生成
                        InitializePanels();
                        Rings.SetActive(true);
                    }
                }
                //一枚描いたら削除
                else
                {
                    //保存が完了したのがわかったら
                    if (sc.saveflag)
                    {
                        Rings.SetActive(false);
                        //リストに格納されていたら
                        if (list_ClearPanels.Count != 0)
                        {
                            StartCoroutine(DestoryClearAllPanels());
                        }
                    }
                }
            }
            //ヘルパーモードの時
            else
            {
                if (ClearPanel.activeInHierarchy)
                {
                    ClearPanel.SetActive(false);
                    Rings.SetActive(false);
                }
                //リストに格納されていたら
                if (list_ClearPanels.Count != 0)
                {
                    StartCoroutine(DestoryClearAllPanels());
                }
            }
        }

        bool isrunning;
        public void InitializePanels()
        {
            if (!isrunning)
            {
                isrunning = true;
                StartCoroutine(Initialize());
            }            
        }

        IEnumerator Initialize()
        {
            //現在あるパネルをすべて削除
            yield return StartCoroutine(DestoryClearAllPanels());
            //新しく生成する
            yield return StartCoroutine(CreatClearPanels(complexity));
            isrunning = false;
        }

        IEnumerator CreatClearPanels(int num)
        {
            Debug.Log("魔法陣用パネルを生成します 個数:" + num.ToString());
            //生成する
            for (int i = 0; i < num; i++)
            {
                //インスタンスを作成
                GameObject Panel_instance = Instantiate(ClearPanel, this.transform) as GameObject;

                //座標の調整
                Transform tf = Panel_instance.gameObject.GetComponent<Transform>();
                Panel_instance.gameObject.GetComponent<Transform>().position = new Vector3(tf.position.x, tf.position.y -15, -0.05f);

                //回転させる
                //奇数個目は反転
                if(i%2 == 1)
                {
                    tf.rotation = Quaternion.Euler((float)360 * i / num - 90, -90, 270);
                }
                else
                {
                    tf.rotation = Quaternion.Euler((float)360 * i / num - 90, -90, 90);
                }
                

                //生成したインスタンスをリストで持っておく
                list_ClearPanels.Add(Panel_instance);
            }
            yield return null;
        }

        IEnumerator DestoryClearAllPanels()
        {
            Debug.Log("魔法陣用パネルを削除します 個数:" + list_ClearPanels.Count.ToString());
            //リストで保持しているインスタンスを削除
            for (int i = 0; i < list_ClearPanels.Count; i++)
            {
                Destroy(list_ClearPanels[i]);
            }

            //リスト自体をキレイにする
            list_ClearPanels.Clear();

            yield return null;
        }

    }
}


