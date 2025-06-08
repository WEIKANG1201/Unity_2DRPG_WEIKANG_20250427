namespace WEIKANG
{
    ///<summary>
    ///玩家落下
    ///</summary>
    public class PlayerFall : State
    {
        public PlayerFall(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }
    }
}