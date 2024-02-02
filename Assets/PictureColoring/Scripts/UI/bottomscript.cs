using BizzyBeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bottomscript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<RectTransform> listChill = null;
    void Start()
    {
        var widthChil = (UnityEngine.Screen.width-100)/listChill.Count;
        Debug.Log(UnityEngine.Screen.width.ToString());
        foreach (var chill in listChill)
        {
            chill.sizeDelta = new Vector2(widthChil, chill.sizeDelta.y);
        }
    }

}
