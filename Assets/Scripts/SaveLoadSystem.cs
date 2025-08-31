using UnityEngine;

namespace WEIKANG {
    /// <summary>
    /// 存讀檔系統
    /// </summary>

    public class SaveLoadSystem : MonoBehaviour
    {
        #region 單例模式
        private static SaveLoadSystem _instance;
        public static SaveLoadSystem instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<SaveLoadSystem>();
                return _instance;
            }

        }
        #endregion

        [SerializeField]
        private PlayerData playerData;

        private Transform playerTransform;
        private Player player;
     

        private void Awake()
        {
            //playerTransform = gameObject.Find("騎士").GetComponent<Transform>();
            playerTransform = GameObject.Find("騎士").transform;
            player = GameObject.Find("騎士").GetComponent<Player>();
        }

        private void Start()
        {
            //測試:喚醒時獲得存檔資料
            SaveData();
        }
        ///<summary>
        ///存檔
        /// </summary>
        public void SaveData()
        {
            playerData.position = playerTransform.position;
            playerData.rotation = playerTransform.eulerAngles;
            playerData.hpMax = player.hpMaxData;
            playerData.hp = player.hpMaxData;
            playerData.hp = player.hpData;
      
        }
    }
}
