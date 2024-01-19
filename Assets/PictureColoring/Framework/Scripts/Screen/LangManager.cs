using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BizzyBeeGames
{

    public class LangManager : SaveableManager<LangManager>
    {
        public ChangeLanaguage ChangeLang_start = null;
        public ChangeLanaguage ChangeLang = null;
        public ChangeLanaguage DoneOnload = null;
        #region save
        protected override void Awake()
        {
            base.Awake();
            InitSave();
        }
        public override string SaveId { get { return "language_changConfig"; } }
        public override Dictionary<string, object> Save()
        {
            Dictionary<string, object> json = new Dictionary<string, object>();

            json["langguageId"] = ChangeLang_start.Index;
            return json;
        }

        protected override void LoadSaveData(bool exists, JSONNode saveData)
        {
            if (exists)
            {
                ChangeLang_start.Index = saveData["langguageId"].AsInt;
            }
            else
            {
                ChangeLang_start.Index = 0;
            }
        }
#endregion
    }
}
