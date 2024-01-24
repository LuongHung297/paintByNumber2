using BizzyBeeGames.PictureColoring;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace BizzyBeeGames
{
	public class SettingsPopup : Popup
	{
		#region Inspector Variables

		[Space]
        [SerializeField] private Onclick toggleOnclick;
        [SerializeField] private ToggleSlider	musicToggle = null;
		[SerializeField] private ToggleSlider	soundToggle = null;
		#endregion

		#region Unity Methods

		private void Start()
		{
			musicToggle.SetToggle(SoundManager.Instance.IsMusicOn, false);
			soundToggle.SetToggle(SoundManager.Instance.IsSoundEffectsOn, false);

			musicToggle.OnValueChanged += OnMusicValueChanged;
            soundToggle.OnValueChanged += OnSoundEffectsValueChanged;
			if (SoundManager.Instance.IsMusicOn)
			{
				toggleOnclick.setToggleOn(true);
			}
			else
			{
				toggleOnclick.setToggleoff(false);
			}
		}

        #endregion

        #region Private Methods
        private void OnMusicValueChanged(bool isOn)
		{
            if (isOn)
            {
                toggleOnclick.setToggleOn(true);
            }
            else
            {
                toggleOnclick.setToggleoff(false);
            }
            SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.Music, isOn);
		}

		private void OnSoundEffectsValueChanged(bool isOn)
		{
			SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.SoundEffect, isOn);
		}

    }
		#endregion
}
