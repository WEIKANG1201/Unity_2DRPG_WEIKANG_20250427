using UnityEngine;

namespace WEIKANG
{
    public class PlayerState: State
    {
       
        protected Player player;
  
        //建構子:實例化時會被呼叫,名稱與類別相同
        public PlayerState(Player _player, StateMachine _stateMachine, string _name)
        {
            player = _player;
            stateMachine = _stateMachine;
            name = _name;
        }
    }
}
