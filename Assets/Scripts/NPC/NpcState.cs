using UnityEngine;

namespace WEIKANG
{
    public class NpcState : State
    {
        protected NPC npc;
        protected StateMachine stateMachine;
        protected string name;

        public NpcState(Player player, StateMachine stateMachine, string name, NPC _npc, StateMachine _stateMachine)
          : base(player, stateMachine, name)
        {
            player = player;
            npc = _npc;
            stateMachine = stateMachine;
            name = name;
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
