using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ObjectSpawner : NetworkBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject parentObject;

    Material syncmaterial;

    [SerializeField] Material material;
    [SerializeField] GameObject Camera;


    public void SpawnPrefab()
    {
        int num = Random.Range(0, prefabs.Length);
        Vector3 pot = new Vector3(Random.Range(0f, 10f), 0.5f, Random.Range(0f,10f));
        GameObject go = Instantiate(prefabs[num],parentObject.transform) as GameObject;

        go.GetComponent<Transform>().localPosition = pot;
        go.GetComponent<Transform>().rotation = Quaternion.identity;

        NetworkServer.Spawn(go);
        RpcChangeMaterial();
    }

    private void Update()
    {

    }

    [ClientRpc]
    void RpcChangeMaterial()
    {
        //nullではない　同じマテリアルではない時
        if (material != null)
        {
            Skybox sb = Camera.GetComponent<Skybox>();
            //マテリアルを適応
            sb.material = material;
            Debug.Log("マテリアル変更");
        }
    }
}