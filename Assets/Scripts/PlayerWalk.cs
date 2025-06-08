using UnityEngine;

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

            //加速度
            player.SetVelocity(new Vector2(h * player.moveSpeed, player.rig.velocity.y));
            //移動動畫
            player.ani.SetFloat("移動", Mathf.Abs(h));
            //翻面
            player.Flip(h);
            //如果 玩家水平值 等於0 就請狀態機 切換到 待機狀態
            if (h == 0) stateMachine.SwitchState(player.playerIdle);
        }
    }
}