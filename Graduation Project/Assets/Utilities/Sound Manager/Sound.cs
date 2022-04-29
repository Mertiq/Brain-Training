using System;
using UnityEngine;

[Serializable]
public class Sound
{
    [Header("*****Input values")]
    [SerializeField] private string name;
    [SerializeField] private AudioClip audioClip;
    [Range(0,1)]
    [SerializeField] private float volume;
    [SerializeField] private bool loop;
    

    [Header("*****Developers only")] 
    [SerializeField] private AudioSource audioSource;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public AudioClip AudioClip
    {
        get => audioClip;
        set => audioClip = value;
    }

    public float Volume
    {
        get => volume;
        set => volume = value;
    }

    public bool Loop
    {
        get => loop;
        set => loop = value;
    }

    public AudioSource AudioSource
    {
        get => audioSource;
        set => audioSource = value;
    }
}

