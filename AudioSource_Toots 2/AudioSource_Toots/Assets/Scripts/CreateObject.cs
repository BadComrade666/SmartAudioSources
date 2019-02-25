using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{


    private AudioSource _AudioSpeaker;
    public AudioClip sampleClip;
    AudioClip[] sounds;
    int index;
    public int count = 0;
    public int maxVoices = 10;
    int voiceNumber = 0;
    //GameObject[] sphere;


    // Use this for initialization
    void Start()
    {
        sounds = Resources.LoadAll<AudioClip>(""); 
        //StartCoroutine("Instantiate");

    }

    // Update is called once per frame
    void Update()
    {

        if (voiceNumber < maxVoices)
        {
            voiceNumber++;

            CreateSphere();
        }

    }


    void CreateSphere()
    {
        

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), Random.Range(-5f, 5f));

            _AudioSpeaker = GetComponent<AudioSource>();
            if (_AudioSpeaker == null)
            {
                _AudioSpeaker = gameObject.AddComponent<AudioSource>();
            }


            index = (int)Random.Range(0f, sounds.Length);
            _AudioSpeaker.clip = sounds[index];

            _AudioSpeaker.spatialBlend = 1.0f;
            _AudioSpeaker.maxDistance = 10f;
            _AudioSpeaker.minDistance = 5f;
            _AudioSpeaker.volume = Random.Range(0.5f, 1f);
            _AudioSpeaker.pitch = Random.Range(0.3f, 3f);
            _AudioSpeaker.Play();


    }

    IEnumerator Instantiate()
    {

        while (true)
        {
            CreateSphere();
            yield return new WaitForSeconds(1f);
        }

    }
}