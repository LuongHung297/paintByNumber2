using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace BizzyBeeGames.PictureColoring
{
	public class CategoryListItem : ClickableListItem
	{
		#region Inspector Variables

		[SerializeField] private TextMeshProUGUI	categoryText	= null;
		[SerializeField] private Image	underlineObject	= null;
		[SerializeField] private Sprite	selectImage	;
		[SerializeField] private Sprite	OnselectImage	;
		[SerializeField] private LocalizeStringEvent loca;

		#endregion

		#region Public Methods

		public void Setup(string displayText)
		{
			categoryText.text = displayText;
            loca.StringReference.TableReference = "CategoriRender";
			if (displayText != null)
			{
				loca.StringReference.TableEntryReference = displayText.ToLower();
            }
        }

		public void SetSelected(bool isSelected)
		{
			categoryText.color		= isSelected ? Color.white : Color.black;
			underlineObject.sprite = OnselectImage;
            underlineObject.color = isSelected ? Color.white : Color.clear ;
			if(selectImage != null && !isSelected)
			{
                underlineObject.color = Color.white;
				underlineObject.sprite = selectImage;
			}
            //underlineObject.gameObject.SetActive(isSelected);
        }

		#endregion
	}
}
