
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using UnityEditor;

public class objectController:NetworkBehaviour{ //オブジェクト操作用Class
	public GameObject post;
	public GameObject fence;
	public GameObject car;
	public GameObject mushroom;
	public GameObject gift;
	public GameObject snowman;
	public GameObject christmasTree;
	public GameObject swing;
	public GameObject house;
	public GameObject flower;
	public GameObject snowyTree;
	public GameObject tree;
	public GameObject palmTree;
	public GameObject bodyBoard;
	public GameObject boat;
	public GameObject parasol;
	public GameObject wateringCan;
	public GameObject treasureBox;

	private GameObject obj;
	private bool ObjState=false;
    //	Material mat = (Material)Resources.Load ("Materials/WaterBasicDaytime");

    List<GameObject> list_Objects = new List<GameObject>();

    public void createObj(string tagname,int index){
		if (ObjState) {
			obstacleDestroy (tagname);
		} if (!ObjState) {
			switch(index){
			case 0:
				obj = Instantiate (fence);//Human
				obj.tag = tagname;
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.transform.rotation = Quaternion.Euler (0, 0, 0);
				obj.transform.position=new Vector3(-110.0f,-100.0f,5.0f);
                list_Objects.Add(obj);
                obj = Instantiate (fence);//Human
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position=new Vector3(-106.0f,-100.0f,5.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
				break;
			case 1:
				obj = Instantiate (house);//House
				obj.tag = tagname;
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.transform.rotation = Quaternion.Euler (-90, 0, 0);
				obj.transform.position=new Vector3(-100.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
				break;
			case 2:
				obj = Instantiate (post);//Fish
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.transform.rotation = Quaternion.Euler (0, 0, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-105.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 3:
				obj = Instantiate (car);//Car
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-112.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 4:
				obj = Instantiate (mushroom);//Mushroom
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-108.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 5:
				obj = Instantiate (gift);//PresentBoxes
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-101, -100, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-99, -100, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-98, -100, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);

                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-100.5f, -99, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-99.5f, -99, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-98.5f, -99, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);

                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-99, -98, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-100f, -98, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);

                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.transform.position = new Vector3 (-99.5f, -97, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);

                obj = Instantiate (gift);
				obj.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.tag = tagname;
				obj.transform.parent = transform;
				obj.transform.position=new Vector3(-100.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 6:
				obj = Instantiate (snowman);//Snowman1
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.transform.rotation = Quaternion.Euler (0, 190, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-94.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 7:
				obj = Instantiate (snowman);//Snowman2
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.transform.rotation = Quaternion.Euler (0, 180, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-104.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 8:
				obj = Instantiate (christmasTree);//ChristmasTree
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				//obj.transform.rotation = Quaternion.Euler (0, 90, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-91.0f,-100.0f,5.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 9:
				obj = Instantiate (swing);//swing
				obj.transform.localScale = new Vector3 (10.0f, 10.0f, 10.0f);
				obj.transform.rotation = Quaternion.Euler (-90, -150, 0);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-96.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 10:
				obj = Instantiate (flower);//flower
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-98.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 11:
				obj = Instantiate (snowyTree);//snowyTree
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-92.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 12:
				obj = Instantiate (tree);//Tree
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-112.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 13:
				obj = Instantiate (palmTree);//palmTree
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-104.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 14:
				obj = Instantiate (bodyBoard);//bodyBoard
				obj.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-100.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 15:
				obj = Instantiate (boat);//boat
				obj.transform.localScale = new Vector3 (0.005f, 0.005f, 0.005f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-110.0f,-100.0f,5.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 16:
				obj = Instantiate (parasol);//parasol
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-109.0f,-100.0f,0.0f);
				obj.transform.rotation = Quaternion.Euler (-89.98f, 0, 0);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 17:
				obj = Instantiate (wateringCan);//wateringCan
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				obj.tag = tagname;
				obj.transform.position=new Vector3(-112.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			case 18:
				obj = Instantiate(treasureBox);
				obj.transform.localScale = new Vector3 (5,5,5);
				obj.tag = tagname;
				obj.transform.position = new Vector3(-94.0f,-100.0f,0.0f);
				NetworkServer.Spawn(obj);
                list_Objects.Add(obj);
                break;
			default:
				break;
			}
		}
	}

//	public void AddTag(string tagname) {//タグ追加
//		UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
//		if ((asset != null) && (asset.Length > 0)) {
//			SerializedObject so = new SerializedObject(asset[0]);
//			SerializedProperty tags = so.FindProperty("tags");
//
//			for (int i = 0; i < tags.arraySize; ++i) {
//				if (tags.GetArrayElementAtIndex(i).stringValue == tagname) {
//					return;
//				}
//			}
//
//			int index = tags.arraySize;
//			tags.InsertArrayElementAtIndex(index);
//			tags.GetArrayElementAtIndex(index).stringValue = tagname;
//			so.ApplyModifiedProperties();
//			so.Update();
//		}
//	}
    
    
    private void RpcobjectsDestroy()
    {
        Debug.Log("オブジェクトを削除します " + list_Objects.Count);
        //リストで保持しているインスタンスを削除
        for (int i = 0; i < list_Objects.Count; i++)
        {
            Destroy(list_Objects[i]);
        }

        //リスト自体をキレイにする
        list_Objects.Clear();
    }

    public void ObjectsDestroyBtn()
    {
        RpcobjectsDestroy();
    }

	public void obstacleDestroy(string tagname) {//オブジェクト消去
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag(tagname);
		Debug.Log (obstacles);
		foreach(GameObject obs in obstacles) {
			Destroy(obs);
		}
	}
}
