using BizzyBeeGames.PictureColoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BizzyBeeGames
{
    public class OnLoadManager : SaveableManager<OnLoadManager>
    {
        public bool Isdone = false;
        public ScreenManager gameScreen;

        #region save
        protected override void Awake()
        {
            base.Awake();
            InitSave();
        }
        public override string SaveId { get { return "StartConfig"; } }
        public override Dictionary<string, object> Save()
        {
            Dictionary<string, object> json = new Dictionary<string, object>();

            json["DoneOnload"] = Isdone;
            return json;
        }

        protected override void LoadSaveData(bool exists, JSONNode saveData)
        {
            if (exists)
            {
                Isdone = saveData["DoneOnload"].AsBool;
            }
            else
            {
                Isdone = false;
            }
            ChangeScreen(Isdone);
        }
        public void ChangeScreen(bool done)
        {
            Isdone = done;
            gameScreen.setHome(Isdone ? "main" : "start");
        }
        #endregion
    }
}