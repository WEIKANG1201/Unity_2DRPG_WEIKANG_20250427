using UnityEngine;

namespace WEIKANG 
{ 
/// <summary>
/// 敵人:敵人的資料與行為
/// </summary>
public class Enemy : Character
  {
        [field: SerializeField]
        public Vector2 idleTime { get; private set; } = new Vector2(1, 3);
        [field: SerializeField]
        public Vector2 wanderTime { get; private set; } = new Vector2(2, 5);
        public StateMachine stateMachine { get; private set; }
     public EnemyIdle enemyIdle { get; private set; }
     public EnemyWander enemyWander { get; private set; }
     public EnemyTrack enemyTrack { get; private set; }
     public EnemyAttack enemyAttack { get; private set; }
     public EnemyDead enemyDead { get; private set; }

     protected override void Awake()
     {
            base.Awake();

            stateMachine = new StateMachine();
            enemyIdle = new EnemyIdle(this, stateMachine, "敵人待機");
            enemyWander = new EnemyWander(this, stateMachine, "敵人遊走");
            enemyTrack = new EnemyTrack(this, stateMachine, "敵人追蹤");
            enemyAttack = new EnemyAttack(this, stateMachine, "敵人攻擊");
            enemyDead = new EnemyDead(this, stateMachine, "敵人死亡");

     }
        private void Update()
        {
            stateMachine.UpdateState();
        }
    }
}
