using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
namespace BizzyBeeGames.PictureColoring
{
    public class setupscreen : Screen
    {
        public ToggleGroup LangGr;
        public GameObject DisplayLangText;
        public override void OnShowing()
        {
            var code = LocalizationSettings.SelectedLocale.Identifier.Code;
            if (LangGr != null)
            {
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
            if (DisplayLangText != null)
            {
                var data = DisplayLangText.GetComponent<LocalizeStringEvent>();
                data.StringReference.TableReference = "Language v1.0";
                data.StringReference.TableEntryReference = "lang." + code;
            }
        }
    }
}