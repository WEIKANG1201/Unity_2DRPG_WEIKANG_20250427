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

        private const string dataName = "遊戲儲存資料";
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
        /// 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha8)) SaveData();
            if (Input.GetKeyDown(KeyCode.Alpha9)) LoadData();
        }
        public void SaveData()
        {
            playerData.position = playerTransform.position;
            playerData.rotation = playerTransform.eulerAngles;
            playerData.hpMax = player.hpMaxData;
            playerData.hp = player.hpMaxData;
            playerData.hp = player.hpData;

            //存檔格式 JSON 輕而且快速的文字格式
            var json = JsonUtility.ToJson(playerData);
            Debug.Log(json);

            // 將轉為JSON格式的字串 儲存到本機端 名稱為"遊戲儲存資料"
            PlayerPrefs.SetString(dataName, json);
        }

        public void LoadData()
        {
            //讀取本機端的檔案
            var json = PlayerPrefs.GetString(dataName);
           
            //將讀取到的字串 轉為 PlayerData 類別
            playerData = JsonUtility.FromJson<PlayerData>(json);
            //將讀取到的資料 指定給 玩家
            playerTransform.position = playerData.position;
            playerTransform.eulerAngles = playerData.rotation;
            player.LoadHpUpdateUI(playerData.hpMax, playerData.hp);
        }
    }
}
