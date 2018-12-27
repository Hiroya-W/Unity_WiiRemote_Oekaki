using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereParticleCtl : MonoBehaviour {

    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = this.gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Particleplay()
    {
        ps.Play();
    }

    public IEnumerator Particleplaydelay()
    {
        yield return new WaitForSeconds(0.5f);
        ps.Play();
    }
}
