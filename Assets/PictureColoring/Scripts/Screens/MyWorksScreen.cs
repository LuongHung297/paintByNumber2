using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames.PictureColoring
{
	public class MyWorksScreen : Screen
	{
		#region Inspector Variables

		[Space]

		[SerializeField] private LevelListItem		listItemPrefab		= null;
		[SerializeField] private GridLayoutGroup	listContainer		= null;
		[SerializeField] private ScrollRect         listScrollRect      = null;
		[SerializeField] private GameObject			emptyS;

		#endregion

		#region Member Variables

		private List<LevelData>						myWorksLevelDatas;
		private RecyclableListHandler<LevelData>	listHandler;
		private bool nowTab  = false;
		#endregion

		#region Properties

		#endregion

		#region Unity Methods

		public override void Initialize()
		{
			base.Initialize();

			// Set the cells size based on the width of the screen
			Utilities.SetGridCellSize(listContainer);

			SetupLibraryList();

			GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelPlayedEvent, OnLevelPlayedEvent);
			GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelCompletedEvent, OnLevelCompletedEvent);
			GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelProgressDeletedEvent, OnLevelDeletedEvent);
		}

		public override void OnShowing()
		{
			if (listHandler != null)
			{
				listHandler.Refresh();
			}
			if (myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == nowTab).Count() > 0)
            {
                emptyS.SetActive(false);
            }
            else
			{
                emptyS.SetActive(true);

            }
        }

		#endregion

		#region Private Methods

		private void OnLevelPlayedEvent(string eventId, object[] data)
		{
			// Add the LevelData that has started playing to the list of my works level datas
			myWorksLevelDatas.Add(data[0] as LevelData);

			// Update the list handler with the new list of level datas
			listHandler.UpdateDataObjects(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == nowTab).ToList());
		}

		private void OnLevelCompletedEvent(string eventId, object[] data)
		{
			LevelData levelData = data[0] as LevelData;

			// Remove the LevelData that was completed and re-insert it 
			myWorksLevelDatas.Remove(levelData);
			myWorksLevelDatas.Insert(0, levelData);

			// Update the list handler with the new list of level datas
			listHandler.UpdateDataObjects(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted  == nowTab).ToList());
		}

		private void OnLevelDeletedEvent(string eventId, object[] data)
		{
			LevelData levelData = data[0] as LevelData;

			// Remove the deleted LevelData
			myWorksLevelDatas.Remove(levelData);

			// Update the list handler with the new list of level datas
			listHandler.UpdateDataObjects(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == nowTab).ToList());
            if (myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == nowTab).Count() > 0)
            {
                emptyS.SetActive(false);
            }
            else
            {
                emptyS.SetActive(true);
            }
        }

		/// <summary>
		/// Clears then resets the list of library level items using the current active category index
		/// </summary>
		private void SetupLibraryList()
		{
			GameManager.Instance.GetMyWorksLevelDatasSplit(out myWorksLevelDatas,1);

			if (listHandler == null)
			{
				listHandler = new RecyclableListHandler<LevelData>(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted ==  nowTab).ToList(), listItemPrefab, listContainer.transform as RectTransform, listScrollRect);

				listHandler.OnListItemClicked = GameManager.Instance.LevelSelected;

				listHandler.Setup();
			}

            //else
            //{
            //	listHandler.UpdateDataObjects(myWorksLevelDatas.Where(x=>x.LevelSaveData.isCompleted == true).ToList());
            //}
        }
        public void changedata(bool tab)
        {
			nowTab = tab;
            listHandler.UpdateDataObjects(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == tab).ToList());
			if(myWorksLevelDatas.Where(x => x.LevelSaveData.isCompleted == tab).Count() > 0)
			{
                emptyS.SetActive(false);

			}
			else
			{
				emptyS.SetActive(true);
			}
        }

        #endregion
    }
}
