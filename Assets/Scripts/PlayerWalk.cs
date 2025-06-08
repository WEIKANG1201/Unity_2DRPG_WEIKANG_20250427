namespace WEIKANG
{
    ///<summary>
    ///玩家走路
    ///</summary>
    public class PlayerWalk : State
    {
        public PlayerWalk(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }
    }
}