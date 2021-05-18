using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MusicSFX 
{
    class Music : MonoBehaviour
    {
        public String name;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 2f)]
        public float pitch;

        public AudioSource SoundSource;

        int volDivider;

        private void Awake()
        {
            volDivider = Assets.Scripts.MusicSFX.VolumeSettings.volValue;
        }

        
    }
}
