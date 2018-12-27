using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

//NetworkManagerクラスを継承する(NetworkBehaviourではないので注意)
public class NetworkManager_Custom : NetworkManager
{
    //ButtonStartHostボタンを押した時に実行
    //IPポートを設定し、ホストとして接続
    public void StartupHost()
    {
        Debug.Log("StartupHost");
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    //ButtonJoinGameボタンを押した時に実行
    //IPアドレスとポートを設定し、クライアントとして接続
    public void JoinGame()
    {
        Debug.Log("JoinGame");
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        //Input Fieldに記入されたIPアドレスを取得し、接続する
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    //ポートの設定
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    //UnityデフォルトのAPI シーンをロードした時にlevelを引数に実行
    //各シーンのlevelはBuild Settingsにて設定
    void OnLevelWasLoaded(int level)
    {
        Debug.Log("LevelWasLoaded " + level.ToString() );
        if (level == 0)
        {
            //Menuシーンへ移動した場合
            SetupMenuSceneButtons();
        }
        else
        {
            //他のシーン(Mainシーン)へ移動した場合
            SetupOtherSceneButtons();
        }
    }

    void SetupMenuSceneButtons()
    {
        //RemoveListener: Buttonのイベントを削除する
        //AddListener: ボタンのイベントを登録する
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
    }

    void SetupOtherSceneButtons()
    {
        //DisconnectボタンにStopHostメソッドを登録する
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}