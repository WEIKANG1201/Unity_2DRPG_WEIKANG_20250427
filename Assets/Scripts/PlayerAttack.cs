using UnityEngine;

namespace WEIKANG
{
    ///<summary>
    ///玩家攻擊
    ///</summary>
    public class PlayerAttack : State
    {
        public PlayerAttack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.ani.SetTrigger("觸發攻擊");
            //凍結全部剛體
            player.rig.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void Exit()
        {
            base.Exit();
            player.rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Update()
        {
            base.Update();
            Debug.Log($"<color=#ff3>計時器:{timer}</color>");
            //移動動畫歸零
            player.ani.SetFloat("移動", 0);
            //如果 計時器 >= 0.7秒 就切換回待機
            if (timer >= 0.7f) stateMachine.SwitchState(player.playerIdle);
        }
    }
}
