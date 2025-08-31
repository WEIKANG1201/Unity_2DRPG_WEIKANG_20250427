using UnityEngine;

namespace WEIKANG
{
    ///<summary>
    ///系統的序列化(Serializable):允許類別顯示在面板上
    ///玩家資料:存讀檔需要的相關資料
    ///玩家座標 角度 血量及老人任務道具獲得數量...
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public Vector3 position;
        public Vector3 rotation;
        public float hpMax;
        public float hp;
        public int missionCountOldMan;
    }
}
