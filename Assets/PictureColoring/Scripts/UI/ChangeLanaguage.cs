using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using BizzyBeeGames.PictureColoring;
using BizzyBeeGames;
using System;
namespace BizzyBeeGames.PictureColoring
{
    public class ChangeLanaguage : MonoBehaviour
    {

        public bool isStart = false;
        public LangManager LangManager = null;
        private bool _active = false;

        // Start is called before the first frame update


        public void ChangeLocale()
        {
            if (_active)
            {
                return;
            }
            StartCoroutine(SetLocale());

        }
        public void SetLangIndex(int id)
        {
            LangManager.Index = id;
            if (isStart)
            {
                ChangeLocale();
            }

        }
        private IEnumerator SetLocale()
        {
            _active = true;
            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LangManager.Index];
            _active = false;
        }
        //public void ChangeLang(int id) {
        //    Debug.Log(id.ToString());
        //}
        // Update is called once per frame
    }
}