using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
namespace BizzyBeeGames.PictureColoring
{
    public class LogoSrceen : Screen
    {
        public Button nextButon = null;
        public StartScreen start = null;
        public float timeDelay = 2f;
        public void Start()
        {

            StartCoroutine(addClick());

        }

        private IEnumerator addClick()
        {
            yield return new WaitForSeconds(timeDelay);
            nextButon.onClick.AddListener(() => start.ShowSubScreen("language"));
        }
    }
}