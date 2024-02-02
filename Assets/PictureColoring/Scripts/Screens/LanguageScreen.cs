using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
namespace BizzyBeeGames.PictureColoring
{
    public class Language : Screen
    {
        public ToggleGroup LangGr;
        public override void OnShowing()
        {
            if (LangGr != null)
            {
                var code = LocalizationSettings.SelectedLocale.Identifier.Code;
                var data = LangGr.GetComponentsInChildren<Toggle>();
                //LangGr.SetAllTogglesOff();
                switch (code)
                {
                    case "en-US":
                        data[0].isOn = true;
                        break;
                    case "de":
                        data[1].isOn = true;
                        break;
                    default:
                        data[0].isOn = true;
                        return;
                }
            }
            //MobileAdsManager.Instance.ShowBannerAd();
        }
    }
}