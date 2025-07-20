using UnityEngine;

namespace WEIKANG
{
    public class NpcState : State
    {
        protected NPC npc;
        protected StateMachine stateMachine;
        protected string name;

        public NpcState(NPC _npc, StateMachine _stateMachine, string _name)
          : base(_npc, _stateMachine, _name)
        {
            npc = _npc;
            stateMachine = _stateMachine;
            name = _name;
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
