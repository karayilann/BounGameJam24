using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioScripts
{
    public class VoiceSetting : MonoBehaviour
    {
        [SerializeField] private AudioMixer GameMusic;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider SFXSlider;

        private void Start()
        {
            if(PlayerPrefs.HasKey("musicVolume"))       
            {
                LoadVolume();
            }
            else
            {
                SetMusicVolume();
                SetSFXVolume();
            }
        }
        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            GameMusic.SetFloat("music", Mathf.Log10(volume)*20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        public void SetSFXVolume()
        {
            float volume = SFXSlider.value;
            GameMusic.SetFloat("SFX", Mathf.Log10(volume)*20);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        private void LoadVolume()
        {
            musicSlider.value=PlayerPrefs.GetFloat("musicVolume");
            SFXSlider.value=PlayerPrefs.GetFloat("SFXVolume");

            SetMusicVolume();
            SetSFXVolume();
        }

    }
} 
