﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using BizzyBeeGames.PictureColoring;

namespace BizzyBeeGames
{

    public class LangManager : SaveableManager<LangManager>
    {
        public int Index = 0;
        public ChangeLanaguage ChangeLanaguage = null;
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

            json["langguageId"] = Index;
            return json;
        }

        protected override void LoadSaveData(bool exists, JSONNode saveData)
        {
            if (exists)
            {
                Index = saveData["langguageId"].AsInt;
            }
            else
            {
                Index = 0;
            }
            ChangeLanaguage.ChangeLocale();
        }
#endregion
    }
}
