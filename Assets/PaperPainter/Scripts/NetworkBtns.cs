using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using UnityEngine.UI;

public class NetworkBtns : MonoBehaviour {

    [SerializeField]
    Text IPText;
    
    public void StartupBtn()
    {
        GameObject go = GameObject.Find("NetworkManager");
        if(go == null)
        {
            Debug.Log("NetworkManagerが見つかりませんでした");
        }
        else
        {
            go.GetComponent<NetworkManager_Custom>().StartupHost();
        }
    }

    private void Start()
    {
        // ホスト名を取得する
        string hostname = Dns.GetHostName();

        // ホスト名からIPアドレスを取得する
        IPAddress[] adrList = Dns.GetHostAddresses(hostname);
        foreach (IPAddress address in adrList)
        {
            Debug.Log(address.ToString());
            IPText.text = "IP:" + address.ToString();
        }
    }


}
