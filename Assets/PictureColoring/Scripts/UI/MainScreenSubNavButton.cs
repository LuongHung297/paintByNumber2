using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames.PictureColoring
{
	public class MainScreenSubNavButton : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private GameObject buttonIcon		= null;
        [SerializeField] private GameObject buttonIconActive = null;
        [SerializeField] private TextMeshProUGUI	buttonText		= null;
		[SerializeField] private TMP_ColorGradient normalColor	;
		[SerializeField] private TMP_ColorGradient selectedColor;


        #endregion

        #region Unity Methods

        public void SetSelected(bool isSelected)
		{
            if (isSelected)
            {
                buttonIconActive.SetActive(true);
                buttonIcon.SetActive(false);
                buttonText.color = Color.white;
                buttonText.enableVertexGradient = true;
            }
            else
            {
                buttonIconActive.SetActive(false);
                buttonIcon.SetActive(true);
                buttonText.color = Color.black;
                buttonText.enableVertexGradient = false;

            }
            buttonText.colorGradientPreset = isSelected ? selectedColor : normalColor;
		}

		#endregion
	}
}
