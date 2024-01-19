using BizzyBeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartPOPSet : MonoBehaviour
{
    [SerializeField] private string rewardGrantedPopupId = "";
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClicked);

    }
    private void OnClicked()
    { 
        PopupManager.Instance.Show(rewardGrantedPopupId, null);
    }
}
