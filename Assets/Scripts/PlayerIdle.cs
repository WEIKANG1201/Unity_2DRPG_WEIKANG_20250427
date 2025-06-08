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
    }
}