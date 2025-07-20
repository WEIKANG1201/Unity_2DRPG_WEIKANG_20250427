namespace WEIKANG
{
    ///<summary>
    ///玩家待機
    ///</summary>
    public class PlayerIdle : PlayerGround
    {
        public PlayerIdle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetFloat("移動", 0);
            player.rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
        }

        public override void Exit()
        {
            base.Exit();
            player.rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Update()
        {
            base.Update();
            if (!player.canMove) return;

            //如果 不能移動 就跳出
            // if (!player.canMove) return;

            //如果 玩家水平值 不等於0 就請狀態機 切換到 走路狀態
            if (h != 0) stateMachine.SwitchState(player.playerWalk);
        }
    }
}