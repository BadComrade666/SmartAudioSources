using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudio : MonoBehaviour {

    public float frequency;

	// Use this for initialization
	void Start () {

        frequency = Random.Range(0.5f, 2.0f);

        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().pitch = frequency;
        GetComponent<AudioSource>().volume = 0.1f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
