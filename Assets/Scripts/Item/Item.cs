using UnityEngine;

namespace WEIKANG
{
    ///<summary>
    ///道具
    ///</summary>
    public class Item : MonoBehaviour
    {
        [SerializeField, Header("飛行速度"), Range(0, 20)]
        private float flySpeed = 7;
        [SerializeField, Header("吃掉距離"), Range(0, 5)]
        private float eatDistance = 1.7f;

        private Transform player;

        private void Awake()
        {
            player = GameObject.Find("騎士").transform;
        }
        private void Update()
        {
            FlyToPlayer();
            EatItem();
        }

        ///<summary>
        ///飛向玩家
        ///</summary>
        private void FlyToPlayer()
        {
            //道具的座標 = 二為向量的向前移動(當前座標,目標座標,速度 * 偵數分之一秒)
            transform.position =
                Vector2.MoveTowards(transform.position, player.position,
                flySpeed * Time.deltaTime);
        }

        ///<summary>
        ///吃掉道具
        /// </summary>
        private void EatItem()
        {
            // 距離 = 二維向量 距離 (A座標,B座標)
            float distance = Vector2.Distance(transform.position, player.position);

            // 如果 距離 < 吃掉距離
            if (distance < eatDistance)
            {
                //就刪除此道具
                Destroy(gameObject);
            }
        }
    }
}