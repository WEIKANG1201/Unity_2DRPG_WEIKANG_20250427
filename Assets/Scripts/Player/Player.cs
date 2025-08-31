using System.Collections;
using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region 變數
        [field: Header("基本資料")]
        [field: SerializeField, Range(0, 10)]
        public float moveSpeed { get; private set; } = 3.5f;
        [field: SerializeField, Range(0, 20)]
        public int jumpForce { get; private set; } = 7;
        [field: SerializeField, Range(0, 3)]
        public float attackBreakTime { get; private set; } = 1;
        [field: SerializeField, Range(0, 1)]
        public float[] attackAnimationTime { get; private set; }
        // [SerializeField]
        public Animator ani { get; private set; }
        //[SerializeField]
        public Rigidbody2D rig { get; private set; }

        public bool canMove { get; set; } = false;
        public bool canJump { get; set; } = false;
        public bool canAttack { get; set; } = false;
        [Header("檢查地板資料")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;
        [SerializeField]
        private Vector3 checkGroundOffset;
        [SerializeField]
        private LayerMask layerCanJump;
        #endregion

        // 唯讀屬性簡寫
        public float hpMaxData => hpMax;
        public float hpData => hp;
        #region 狀態機
        public StateMachine stateMachine;
        public PlayerIdle playerIdle { get; private set; }
        public PlayerWalk playerWalk { get; private set; }
        public PlayerJump playerJump { get; private set; }
        public PlayerFall playerFall { get; private set; }
        public PlayerAttack playerAttack{ get; private set; }
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.6f, 0.7f, .06f);
            Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
        }

        private void Awake()
        {
            //取得此物件身上的 Animator 元件 並存放到 ani 變數
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

            //實例化狀態機(產生一個狀態機物件在遊戲內開始執行,與掛在物件上相同)
            stateMachine = new StateMachine();
            // this 指的是指類別(在這裡指的是 Player)
            playerIdle = new PlayerIdle(this, stateMachine, "玩家待機");
            playerWalk = new PlayerWalk(this, stateMachine, "玩家走路");
            playerJump = new PlayerJump(this, stateMachine, "玩家跳躍");
            playerFall = new PlayerFall(this, stateMachine, "玩家落下");
            playerAttack = new PlayerAttack(this, stateMachine, "玩家攻擊");

            //狀態機 指定 預設狀態 為 待機
            stateMachine.DefaultState(playerIdle);

            //測試用:可以控制
            //TestCanControl();
        }

        private void Update()
        {
            //狀態機 更新狀態
            stateMachine.UpdateState();

            Debug.Log($"<color=#ff9>是否碰到地板:{IsGrounded()}</color>");
        }



        /// <summary>設定加速度
        public void SetVelocity(Vector3 velocity)
        {
            rig.velocity = velocity;
        }

        /// <summary> 翻面

        private bool facingRight = true;
        // 將 hpMax 與 hp 從 readonly 改為 private 欄位，並移到區域變數區
        private float hpMax;
        private float hp;
        private object imgHp;
        private object imgHpMax;
        private CanvasGroup groupBlack;

        public void Flip(float h)
        {
            if (Mathf.Abs(h) < 0.1f) return;

            bool shouldFaceRight = h > 0;

            if (shouldFaceRight != facingRight)
            {
                facingRight = shouldFaceRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        ///<summary>
        ///是否在地板上
        ///</summary>
        public bool IsGrounded()
        {
            return Physics2D.OverlapBox(transform.position + checkGroundOffset,
                 checkGroundSize, 0, layerCanJump);
        }

        private void TestCanControl()
        {
            //canMove = true;
            //canJump = true;
            //canAttack = true;
        }

        public void SwitchControl(bool canControl)
        {
            rig.velocity = Vector3.zero;
            stateMachine.SwitchState(playerIdle);
            canMove = canControl;
            canJump = canControl;
            canAttack = canControl;
        }
        ///<summary>
        ///載入血量資料並更新介面
        /// </summary>
        /// <param name="_hpMax">血量最大值</param>
        /// <param name="_hp">血量當前值</param>
        public void LoadHpUpdateUI(float _hpMax, float _hp)
        {
            hp = _hp;
            hpMax = _hpMax;
       
        }
        ///<summary>
        ///載入玩家資料
        /// </summary>
        private IEnumerator LoadPlayerData()
        {
            yield return new WaitForSeconds(2);
            SaveLoadSystem.instance.LoadData();
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FadeSystem.Fade(groupBlack, false));
            Revival();
        }

        /// <summary> 
        /// 復活 
        /// </summary>
        private void Revival()
        {
            ani.SetTrigger("觸發復活");
            stateMachine.SwitchState(playerIdle);
        }
    }
}