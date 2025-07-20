using UnityEngine;

namespace WEIKANG
{
    public class NpcQuesting : NpcState
    {
        public NpcQuesting(NPC _npc, StateMachine _stateMachine, string _name) : base(_npc, _stateMachine, _name)
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
            if (npc.playerInArea && Input.GetKeyDown(KeyCode.E))
            {
                npc.flowchart.SendFungusMessage("任務前");

                //如果 玩家當前道具數量 >= 道具需求數量 就切換到任務完成
                if (npc.itemCountCurrent >= npc.itemCountNeed)
                    stateMachine.SwitchState(npc.questFinish);
            }
        }
    }
}

