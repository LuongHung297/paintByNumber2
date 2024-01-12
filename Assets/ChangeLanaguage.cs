using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
public class ChangeLanaguage : MonoBehaviour
{
    ToggleGroup ToggleGroup;
    int Index = 0;
   public class LangIndex
    {
        int Index {set; get; } 
    }
    // Start is called before the first frame update
    void Start()
    {
        ToggleGroup = GetComponent<ToggleGroup>();
    }
    public void SetIndex(int id)
    {
        Index = id;
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
