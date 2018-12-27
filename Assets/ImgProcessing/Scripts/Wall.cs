using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Wall : NetworkBehaviour
{
	public GameObject skyboxCam;
	// Skyboxのマテリアル
	public Material[] skybox;

[ClientRpc]
	public void RpcChangeSkyboxToSunny(){
		// RenderSettings.skybox = skybox[0];
		Skybox mat = skyboxCam.GetComponent<Skybox>();
		mat.material = skybox[0];
	}
[ClientRpc]
	public void RpcChangeSkyboxToRainy(){
		// RenderSettings.skybox = skybox[1];
		Skybox mat = skyboxCam.GetComponent<Skybox>();
		mat.material = skybox[1];
	}
[ClientRpc]
	public void RpcChangeSkyboxToSnowy(){
		// RenderSettings.skybox = skybox[2];
		Skybox mat = skyboxCam.GetComponent<Skybox>();
		mat.material = skybox[2];
	}

	
}