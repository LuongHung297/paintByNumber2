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
public class ChangeLanaguage : MonoBehaviour
{

    public bool isStart = false;
    //public int Index { get; set; }
    public int Index;

   
    // Start is called before the first frame update
    public void SetIndex(int id)
    {
        Index = id;
        if(isStart) {
            ChangeLocale();
        }

    }
    public void setByStart(int id)
    {
        Index = id;
        if (isStart)
        {
            ChangeLocale();
        }
    }
    private bool _active = false;

    public void ChangeLocale()
    {
        if (_active)
        {
            return;
        }
        StartCoroutine(SetLocale());

    }

    private IEnumerator SetLocale()
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Index];
        _active = false;
    }
    //public void ChangeLang(int id) {
    //    Debug.Log(id.ToString());
    //}
    // Update is called once per frame
}
