using UnityEngine;

namespace WEIKANG
{
    public class NpcQuestFinish : NpcState
    { 
        public NpcQuestFinish(NPC _npc, StateMachine _stateMachine, string _name) : base(_npc, _stateMachine, _name)
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
            if (npc.playerInArea && Input.GetKeyDown(KeyCode.E))
            {
                npc.flowchart.SendFungusMessage("¥ô°È«á");
            }
        }
    }
}

