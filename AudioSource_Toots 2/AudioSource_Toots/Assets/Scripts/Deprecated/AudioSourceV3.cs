﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcev3 : MonoBehaviour
{

    private AudioSource _AudioSpeaker;
    private AudioLowPassFilter lowPassFilter;


    public AudioClip sampleClip;
    public bool loop = false;
    [Range(0f, 1f)]
    public float volume = 0.9f;
    [Range(-3f, 3f)]
    public float pitch = 0.9f;
    [Range(0f, 1f)]
    public float spatialBlend = 1f;
    [Range(-2f, 2f)]
    public float minPitchRange = 1f;
    [Range(-1f, 2f)]
    public float maxPitchRange = 0.5f;
    [Range(0f, 1f)]
    public float minAmpRange = 0.5f;
    [Range(0f, 1f)]
    public float maxAmpRange = 0.5f;

    public List<AudioClip> clips = new List<AudioClip>();
    int index;



    void Awake()
    {
        _AudioSpeaker = GetComponent<AudioSource>();
        if (_AudioSpeaker == null)
        {
            _AudioSpeaker = gameObject.AddComponent<AudioSource>();

        }


    
    }

    // Use this for initialization
    void Start()
    {

       
        if (clips.Count != 0)
        {
            _AudioSpeaker.clip = clips[Random.Range(0, clips.Count - 1)];

            PlayAudio();
        }

        else
        {
            _AudioSpeaker.clip = sampleClip;
            PlayAudio();
        }

    }

    public void SetSourceProperties(AudioClip sampleClip, float volume, float pitch, bool loop, float minRange, float maxRange, float spatialBlend, float minAmpRange, float maxAmpRange)
    {


        _AudioSpeaker.pitch = pitch + Random.Range(minPitchRange, maxPitchRange);
        _AudioSpeaker.volume = volume + (Random.Range(minAmpRange, maxAmpRange));
        _AudioSpeaker.loop = loop;
        _AudioSpeaker.minDistance = minRange;
        _AudioSpeaker.maxDistance = maxRange;
        _AudioSpeaker.spatialBlend = spatialBlend;


    }

    public void PlayAudio()
    {

        SetSourceProperties(sampleClip, volume, pitch, loop, minPitchRange, maxPitchRange, spatialBlend, minAmpRange, maxAmpRange);
        _AudioSpeaker.Play();
    }

    // Update is called once per frame
    void Update()
    {



    }



}
