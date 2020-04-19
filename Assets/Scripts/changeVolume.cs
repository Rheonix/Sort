using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeVolume : MonoBehaviour {

    public Slider musicVolumeSlider;
    public AudioSource gameSoundMusic;

    public Slider sfxVolumeSlider;

    // Below have list of all SFX that would be in the game, setting them equal to the sfxVolumeSlider
    // public AudioSource gameSoundCrateSFX
    // public AudioSource gameSoundsfx;

    private void Start()
    {
        musicVolumeSlider.value = GameControl.control.musicVolume;
        gameSoundMusic.volume = musicVolumeSlider.value;
    }

    public void OnMusicValueChanged()
    {
        gameSoundMusic.volume = musicVolumeSlider.value;
        GameControl.control.musicVolume = musicVolumeSlider.value;
        //GameControl.control.musicVolumeSliderPosition = musicVolumeSlider.value;
    }
}
