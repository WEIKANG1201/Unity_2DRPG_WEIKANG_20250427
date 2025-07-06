using UnityEngine;

namespace WEIKANG
{
    public class PlayerState : State
    {
        public PlayerState(Player player, StateMachine stateMachine, string name)
            : base(player, stateMachine, name)
        {
        }

        // virtual 虛擬:允許子類別覆寫(override)
        public override void Enter()
        {
            Debug.Log($"<color=#f69>進入<{name}> 狀態</color>");
            timer = 0;
        }

        public override void Update()
        {
            Debug.Log($"<color=#999>更新<{name}> 狀態</color>");
            h = Input.GetAxis("Horizontal");
            timer += Time.deltaTime;
        }

        public override void Exit()
        {
            Debug.Log($"<color=#f33>離開<{name}> 狀態</color>");
        }
    }
}
