using BizzyBeeGames;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    public Sprite OnclickImage;
    public GameObject textMeshProUGUI;
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
            //texttocchange.text = "hung";

        }
    }
    public void sutSound(bool ison)
    {
        //musicToggle.SetToggle(SoundManager.Instance.IsMusicOn, false);
        SoundManager.Instance.SetSoundTypeOnOff(SoundManager.SoundType.Music, ison);

    }
}
