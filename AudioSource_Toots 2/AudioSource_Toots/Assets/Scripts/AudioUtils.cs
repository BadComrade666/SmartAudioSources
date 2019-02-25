using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtils
{

    private static float twelfthRootOfTwo = Mathf.Pow(2.0f, 1.0f / 12.0f);

    public static float dbToVolume(float dB) // converts decibels to linear volume
    {
        return Mathf.Pow(10.0f, 0.05f * dB);
    }

    public static float VolumeTodB(float volume) // converts linear volume to decibels
    {
        return 20.0f * Mathf.Log10(volume);
    }

    public static float StToPitch(float st) // converts semitones to pitch
    {
        return Mathf.Clamp(Mathf.Pow(twelfthRootOfTwo, st), 0f, 4f);
    }

    public static float PitchToSt(float pitch) // converts pitch to semitones
    {
        return Mathf.Log(pitch, twelfthRootOfTwo);
    }

}