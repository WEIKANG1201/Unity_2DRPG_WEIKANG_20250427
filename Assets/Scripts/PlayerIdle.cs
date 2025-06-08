namespace WEIKANG
{
    ///<summary>
    ///玩家待機
    ///</summary>
    public class PlayerIdle : State
    {
        public PlayerIdle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            //如果 玩家水平值 不等於0 就請狀態機 切換到 走路狀態
            if (h != 0) stateMachine.SwitchState(player.playerWalk);
        }
    }
}