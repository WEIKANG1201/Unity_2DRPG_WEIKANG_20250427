using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region 變數
        [Header("基本資料")]
        [SerializeField, Range(0, 10)]
        private float moveSpeed = 3.5f;
        [SerializeField, Range(0, 20)]
        private int jumpForce = 7;
        [SerializeField]
        private Animator ani;
        [SerializeField]
        private Rigidbody2D rig;
        [Header("檢查地板資料")]
        [SerializeField]
        private Vector3 checkGroundSize = Vector3.one;
        [SerializeField]
        private Vector3 checkGroundOffset;
        [SerializeField]
        private LayerMask layerCanJump;
        #endregion

        #region 狀態機
        public StateMachine stateMachine;
        public PlayerIdle playerIdle;
        public PlayerWalk playerWalk;
        public PlayerJump playerJump;
        public PlayerFall playerFall;
        public PlayerAttack playerAttack; 
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.6f, 0.7f, .06f);
            Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
        }

        private void Awake()
        {
            //實例化狀態機(產生一個狀態機物件在遊戲內開始執行,與掛在物件上相同)
            stateMachine = new StateMachine();
            // this 指的是指類別(在這裡指的是 Player)
            playerIdle = new PlayerIdle(this,stateMachine,"玩家待機");
            playerWalk = new PlayerWalk(this,stateMachine, "玩家走路");
            playerJump = new PlayerJump(this,stateMachine, "玩家跳躍");
            playerFall = new PlayerFall(this,stateMachine, "玩家落下");
            playerAttack = new PlayerAttack(this,stateMachine, "玩家攻擊");

            //狀態機 指定 預設狀態 為 待機
            stateMachine.DefaultState(playerIdle);
        }

        private void Update()
        {
            //狀態機 更新狀態
            stateMachine.UpdateState();
        }
    }
}

