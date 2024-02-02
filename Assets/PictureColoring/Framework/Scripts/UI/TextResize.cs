using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace BizzyBeeGames
{
	public class TextResize : MonoBehaviour
    {	 
        private Text txt;
        private TextMeshProUGUI textMeshPro;
        private LocalizeStringEvent loca;
        public float padding;
        void Start ()
        {
            txt = GetComponent<Text>();
            textMeshPro = GetComponent<TextMeshProUGUI>();
            loca = GetComponent<LocalizeStringEvent>();
            if(loca != null)
            {
               //loca.OnUpdateString.AddListener(setParentSize);
            }
        }

        void FixedUpdate()
        {
            RectTransform rectTransform = transform.parent.GetComponent<RectTransform>();
            if(txt != null)
            {
                rectTransform.sizeDelta = new Vector2(txt.rectTransform.sizeDelta.x + padding, txt.rectTransform.sizeDelta.y);
            }else if (textMeshPro != null)
            {
                rectTransform.sizeDelta = new Vector2(textMeshPro.rectTransform.sizeDelta.x + padding, textMeshPro.rectTransform.sizeDelta.y);

            }
            
        }


    }
}
