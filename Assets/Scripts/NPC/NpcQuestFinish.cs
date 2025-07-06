using UnityEngine;

namespace WEIKANG
{
    public class NpcQusetFinish : NpcState
    {
        public NpcQusetFinish(Player player, StateMachine stateMachine, string name, NPC _npc, StateMachine npcStateMachine)
      : base(player, stateMachine, name, _npc, npcStateMachine)

        {
            // 你可以在這裡加入初始化邏輯
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
        }
    }
}

