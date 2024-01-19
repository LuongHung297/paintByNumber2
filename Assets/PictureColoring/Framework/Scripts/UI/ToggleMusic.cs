using BizzyBeeGames;
using BizzyBeeGames.PictureColoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public ToggleSlider slider;

    public void OnMusicValueChanged(bool isOn)
    {
        //slider.SetToggle(SoundManager.Instance.IsMusicOn, true);
    }

    //private void OnSoundEffectsValueChanged(bool isOn)
    //{
    //    SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.SoundEffect, isOn);
    //}
}
