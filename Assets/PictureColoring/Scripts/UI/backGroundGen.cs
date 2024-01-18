using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BizzyBeeGames.PictureColoring
{
	public class backGroundGen : MonoBehaviour
	{
		public RectTransform Container;
		public GameObject BoxPrefab;
        public PictureArea PictureArea;
        private GameObject parentFake;
        public Sprite select;
        public void OnEnable()
        {
            ReloadListBack(PictureArea.ListImageToUse_share,PictureArea.texttureSelct);
        }
        public void OnDisable()
        {
            removeBg();
        }
        public void ReloadListBack(Texture2D[] list,int texture)
        {
            var i = 0;
           parentFake = new GameObject("item_list");
           var pa =  parentFake.AddComponent<RectTransform>();
           var hoi =  parentFake.AddComponent<HorizontalLayoutGroup>();
            hoi.spacing = 40;
            hoi.childAlignment = TextAnchor.MiddleRight;
            hoi.childScaleWidth = true;
            hoi.childControlHeight = false;
            hoi.childControlWidth = false;
            hoi.childForceExpandHeight = false;
            hoi.childForceExpandWidth = false;
            pa.SetParent(Container);
            foreach (var item in list)
            {
                int copy = i;
                var data = GameObject.Instantiate(BoxPrefab);
                if(texture == copy)
                {
                    GameObject.FindGameObjectWithTag("previewBg").GetComponent<Image>().sprite = Sprite.Create(item, new Rect(0, 0, item.width, item.height), new Vector2(0.5f, 0.5f));
                    data.GetComponent<Image>().sprite = select;
                }
                var rcdata = data.GetComponent<RectTransform>();
                rcdata.SetParent(pa);
                var imdata = data.GetComponentsInChildren<Image>()[1];
                imdata.sprite = Sprite.Create(item, new Rect(0, 0, item.width, item.height), new Vector2(0.5f, 0.5f));
                var btn =  data.GetComponentInChildren<Button>();
                btn.onClick.AddListener(()=>PictureArea.PictureArenaChange(copy));
                i++;
            }
        }
        public void removeBg()
        {
            Destroy(parentFake);
        }

    }
}
