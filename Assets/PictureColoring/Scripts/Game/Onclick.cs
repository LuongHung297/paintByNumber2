using BizzyBeeGames;
using BizzyBeeGames.PictureColoring;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace BizzyBeeGames.PictureColoring
{
    public class Onclick : MonoBehaviour
    {
        public Sprite OnclickImage;
        public GameObject textMeshProUGUI;
        public Toggle ParentToggle;
        public GameObject ParentToggle_on;
        public GameObject ParentToggle_off;
        public List<Sprite> ParentToggle_Parent;
        private PictureArea PictureArea;
        public void Seclect(Image item)
        {
            var parentChild = item.transform.parent.GetComponentsInChildren<Image>();
            foreach (var data in parentChild)
            {
                data.sprite = null;
                data.color = Color.clear;
                data.GetComponentInChildren<Text>().color = Color.black;
            }
            item.sprite = OnclickImage;
            item.color = Color.white;
            item.GetComponentInChildren<Text>().color = Color.white;

        }
        public void ChangeText(TextMeshProUGUI texttocchange)
        {
            textMeshProUGUI = GameObject.FindGameObjectWithTag("ChangeText");

            if (textMeshProUGUI != null)
            {

                foreach (var data in textMeshProUGUI.GetComponentsInChildren<TextMeshProUGUI>())
                {
                    data.enabled = false;
                }
                texttocchange.enabled = true;

            }
        }
        public void sutSound(bool ison)
        {
            SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.Music, ison);

        }
        public void DropDownActive(GameObject image)
        {
            var data = GameObject.FindGameObjectWithTag("DropIcon");

            data.transform.Rotate(180, 0, 0);
            if (image.activeInHierarchy)
            {
                data.transform.Rotate(0, 0, 0);
                image.SetActive(false);
            }
            else
            {
                image.SetActive(true);

            }
        }
        public void BackgroundSelect(GameObject Self)
        {

            Debug.Log(PictureArea.texttureSelct);
        }


        public void ClickToggel()
        {
            if (ParentToggle.isOn)
            {
                ParentToggle_on.SetActive(true);
                ParentToggle_off.SetActive(false);
                ParentToggle.GetComponent<Image>().sprite = ParentToggle_Parent[0];
            }
            else
            {
                ParentToggle_on.SetActive(false);
                ParentToggle_off.SetActive(true);
                ParentToggle.GetComponent<Image>().sprite = ParentToggle_Parent[1];
            }
            ParentToggle.GetComponent<ToggleMusic>().OnMusicValueChanged(ParentToggle.isOn);

        }

    }
}