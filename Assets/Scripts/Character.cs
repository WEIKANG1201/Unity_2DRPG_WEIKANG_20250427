using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 角色:翻面與加速度或是角色共通功能
    /// </summary>
    public class Character : MonoBehaviour
    {
        public Animator ani { get; private set; }
        public Rigidbody2D rig { get; private set; }

        protected virtual void Awake()
        {
            //獲得此物件身上的 Animator 並存放在 ani 變數
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 設定加速度
        /// </summary>
        /// <param name="="direction">加速度的三維向量</param>
        public void SetVelocity(Vector3 direction)
        {
            rig.velocity = direction;
        }

        /// <summary> 
        /// 翻面
        /// </summary>
        /// <param name="="h">水平值,+1右邊,-1左邊</param>
        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}