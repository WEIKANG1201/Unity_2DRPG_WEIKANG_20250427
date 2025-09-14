using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 敵人狀態
    /// </summary>
    public class EnemyState : State
    {
        private float idleTime;
        protected Enemy enemy;

        public EnemyState(Enemy _enemy, StateMachine _stateMachine, string _name)
            :base(_enemy, _stateMachine, _name)
        {
            enemy = _enemy;
            stateMachine = _stateMachine;
            name = _name;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log($"<color=#f69>進入<{name}> 狀態</color>");
            idleTime = Random.Range(enemy.idleTime.x, enemy.idleTime.y);
            Debug.Log($"待機時間:{idleTime}");
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