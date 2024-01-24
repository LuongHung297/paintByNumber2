using BizzyBeeGames.PictureColoring;
using BizzyBeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Security.AccessControl;
namespace BizzyBeeGames.PictureColoring
{
    public class ListGroup
    {
        public string ListKey { get; set; }
        public List<LevelData> ListData { get; set; }
    }
    public class DailyScreen : Screen
    {
        // Start is called before the first frame update
        #region Inspector Variables
        [Space]
        public Font MeriedaFont;
        //[SerializeField] private LevelListItem levelListItemPrefab = null;
        [SerializeField] private GridLayoutGroup levelListContainer = null;
        //[SerializeField] private ScrollRect levelListScrollRect = null;

        #endregion

        #region Member Variables

        private ObjectPool categoryListItemPool;
        private RecyclableListHandler<LevelData> levelListHandler;
        private List<CategoryListItem> activeCategoryListItems;
        private List<ListGroup> ListGroupData;
       private int activeCategoryIndex;
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            base.Initialize();
            Utilities.SetGridCellSize(levelListContainer);
            SetupLibraryList();
            GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelPlayedEvent, OnLevelGameEvent);
            GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelCompletedEvent, OnLevelGameEvent);
            GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelProgressDeletedEvent, OnLevelGameEvent);
            GameEventManager.Instance.RegisterEventHandler(GameEventManager.LevelUnlockedEvent, OnLevelGameEvent);
        }

        public override void OnShowing()
        {
            if (levelListHandler != null)
            {
                levelListHandler.Refresh();
            }
        }

        #endregion

        #region Private Methods

        private void OnLevelGameEvent(string id, object[] data)
        {
            Debug.Log(id);
            // Call the Setup method on all visible LevelListItems
            levelListHandler.Refresh();
        }

        /// <summary>
        /// Clears then resets the list of library level items using the current active category index
        /// </summary>
        private void SetupLibraryList()
        {
            if (activeCategoryIndex > GameManager.Instance.Categories.Count)
            {
                return ;
            }

            List<LevelData> levelDatas = GameManager.Instance.AllLevels.ToList();

            //GroupData(levelDatas);       
            // Check if this is the first time we are setting up the library list
            if (levelListHandler == null)
            {
                // Create a new RecyclableListHandler to handle recycling list items that scroll off screen     
                //levelListHandler = new RecyclableListHandler<LevelData>(levelDatas, levelListItemPrefab, levelListContainer.transform as RectTransform, levelListScrollRect,true, ListGroupData, MeriedaFont);     

                //levelListHandler.OnListItemClicked = GameManager.Instance.LevelSelected;

                //levelListHandler.Setup();
            }
            else
            {
                // Update the the RecyclableListHandler with the new data set
                levelListHandler.UpdateDataObjects(levelDatas);
            }
        }

        #endregion
        //public void GroupData(List<LevelData> listLevel)
        //{
        //    ListGroupData =  listLevel;
        //}
    }
}