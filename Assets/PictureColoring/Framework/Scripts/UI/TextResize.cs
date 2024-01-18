using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames
{
	public class TextResize : MonoBehaviour
    {	 
        public Text txt;
        public TextMeshProUGUI textMeshPro;
        public Image txtBox;
        public bool onlyH;
        public bool onlyW;
        void Update() {
           
            if(onlyH)
            {
                if (txt == null)
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(txtBox.rectTransform.sizeDelta.x, textMeshPro.rectTransform.sizeDelta.y);
                }
                else
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(txtBox.rectTransform.sizeDelta.x, txt.rectTransform.sizeDelta.y);

                }
            }
            else if(onlyW)
            {
                if (txt == null)
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(textMeshPro.rectTransform.sizeDelta.x, txtBox.rectTransform.sizeDelta.y);
                }
                else
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(txt.rectTransform.sizeDelta.x, txtBox.rectTransform.sizeDelta.y);

                }
            }
            else
            {
                if (txt == null)
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(textMeshPro.rectTransform.sizeDelta.x, textMeshPro.rectTransform.sizeDelta.y);
                }
                else
                {
                    txtBox.rectTransform.sizeDelta = new Vector2(txt.rectTransform.sizeDelta.x, txt.rectTransform.sizeDelta.y);

                }
            }

        }


    }
}
