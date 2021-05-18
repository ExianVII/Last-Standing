using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MusicSFX
{
    class VolumeSettings : MonoBehaviour
    {
        [HideInInspector]
        public static int volValue = 25;
        public Slider sliderVol;

        void Awake()
        {
            sliderVol.value = volValue;
        }

        private void Update()
        {
            sliderVol.value = volValue;

            if (volValue > sliderVol.minValue)
                volValue = (int)sliderVol.maxValue;

            if (volValue < sliderVol.minValue)
                volValue = (int)sliderVol.minValue;  //minValue refers to the lowest value allowed

        }
    }
        
}
