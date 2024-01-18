using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class screenCal : MonoBehaviour
{
    public RectTransform Container, Top_rect,mid_rect,bot_rect;
    //public RectTransform NeedToCal;
    //public List<RectTransform> Children_container_notitself;
    //private float TotalSizeX;
    //private float TotalSizeY;
    protected  void Awake()
    {
        Container = GetComponent<RectTransform>();
        Top_rect = GetComponent<RectTransform>();
        mid_rect = GetComponent<RectTransform>();
        bot_rect = GetComponent<RectTransform>();
    }

    protected  void OnEnable()
    {
        UpdateWidth();
    }

    protected  void OnRectTransformDimensionsChange()
    {
        UpdateWidth(); // Update every time if parent changed
    }

    private void UpdateWidth()
    {
        //mid_rect.sizeDelta =new Vector2 (Container.sizeDelta.x - Top_rect.sizeDelta.x - bot_rect.sizeDelta.x, Container.sizeDelta.y - Top_rect.sizeDelta.y - bot_rect.sizeDelta.y);
    }

}
