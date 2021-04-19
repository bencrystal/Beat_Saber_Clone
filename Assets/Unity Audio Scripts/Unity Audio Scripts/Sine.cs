using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Sine : MonoBehaviour
{

    public double frequency = 440;
    public double gain = 0.05;

    private double increment;
    private double phase;
    private double sampling_frequency = 48000;

    void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2 * Math.PI / sampling_frequency;
        for (int i = 0; i < data.Length; i++)
        {
            phase = phase + increment;
            data[i] = (float)gain * Mathf.Sin((float)phase);
            if (phase > 2 * Math.PI) phase = 0;
        }
    }
}