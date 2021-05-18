using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;


namespace Assets.Scripts.MusicSFX
{
    class HeroMoving : MonoBehaviour
    {
        public GameObject hero;

        public AudioSource HeroJump;
        public AudioClip audio1;
        public AudioSource HeroAttack;
        public AudioClip audio2;
        public AudioSource HeroSkill;
        public AudioClip audio3;

        private void Awake()
        {
            var sounds = GetComponents<AudioSource>();

            foreach(AudioSource s in sounds)
            {
                s.volume = 0.5f;
                s.pitch = 0.5f;
            }

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                  HeroJump.Play();

            if(Input.GetKeyDown(KeyCode.X))
            {
                HeroAttack.PlayDelayed(0.2F);
            }

            if (Input.GetKeyDown(KeyCode.C))
                HeroSkill.Play();

        }
        
    }
}
