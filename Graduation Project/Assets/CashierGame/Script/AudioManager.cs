using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CashierGame
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<Sound> sounds;

        private void Awake()
        {
            foreach (var sound in sounds)
            {
                sound.AudioSource = gameObject.AddComponent<AudioSource>();
                SetAudioSource(sound.AudioSource, sound);
            }
        }

        public void PlaySound(string soundName)
        {
            foreach (var sound in sounds.Where(sound => sound.Name == soundName))
            {
                sound.AudioSource.Play();
            }
        }
        
        private static void SetAudioSource(AudioSource audioSource, Sound sound)
        {
            audioSource.clip = sound.AudioClip;
            audioSource.volume = sound.Volume;
            audioSource.loop = sound.Loop;
        }
    }
}
