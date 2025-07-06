using UnityEngine;

namespace WEIKANG
{
    public class NPC : MonoBehaviour
    {
        public StateMachine stateMachine;
        public NpcQuestBefore questBefore { get; private set; }
        public NpcQuesting questing { get; private set; }
        public NpcQusetFinish qusetFinish { get; private set; }

        private void Awake()
        {
        
        }
    }
}