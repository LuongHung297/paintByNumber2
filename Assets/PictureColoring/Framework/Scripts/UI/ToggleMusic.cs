using BizzyBeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public ToggleSlider slider;
    private void Start()
    {
        slider.SetToggle(SoundManager.Instance.IsMusicOn, false);
        //toggle.SetToggle(SoundManager.Instance.IsSoundEffectsOn, false);

        //toggle.OnValueChanged += OnSoundEffectsValueChanged;
    }
    public void OnMusicValueChanged(bool isOn)
    {
        SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.Music, isOn);
    }

    //private void OnSoundEffectsValueChanged(bool isOn)
    //{
    //    SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.SoundEffect, isOn);
    //}
}
