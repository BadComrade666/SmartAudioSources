using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceRepeating : MonoBehaviour {

    public AudioSource source;
    [Range(-40f, 0f)] // this turns a public variable into a slider in the default inspector
    public float volume;
    [Range(-24f, 0f)]
    public float randomVol;
    [Range(-24, 24f)]
    public float pitch;
    [Range(-24, 24f)]
    public float randomPitch;
    public float minWaitTime;
    public float maxWaitTime;
    public List<AudioClip> clips = new List<AudioClip>();

    void Awake()
    {
        StartCoroutine(PlayRepeat());
    }

    void Update()
    {
    }

    IEnumerator PlayRepeat()
    {
        while (true)
        {
            int index = Random.Range(0, clips.Count - 1);
            float linearVol = AudioUtils.dbToVolume(Random.Range(volume + randomVol, volume));
            float linearPitch = AudioUtils.StToPitch(Random.Range(pitch - randomPitch, pitch + randomPitch));
            source.clip = clips[index];
            source.volume = linearVol;
            source.pitch = linearPitch;
            source.Play();
            float waitTime = Random.Range(minWaitTime, maxWaitTime); // get a random float between your minimum and maximum wait time
            yield return new WaitForSeconds(source.clip.length + waitTime); // wait for the length of the audio clip + the wait time
        }
    }
}
