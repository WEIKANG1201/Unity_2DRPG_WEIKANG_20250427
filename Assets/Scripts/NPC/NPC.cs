using Fungus;
using System.Collections;
using UnityEngine;

namespace WEIKANG
{
    public class NPC : MonoBehaviour
    {
        public StateMachine stateMachine;
        public NpcQuestBefore questBefore { get; private set; }
        public NpcQuesting questing { get; private set; }
        public NpcQuestFinish questFinish { get; private set; }
        public Flowchart flowchart { get; private set; }
        public bool playerInArea { get; private set; }

        [SerializeField]
        private Vector3 offsetInteraction;

        private CanvasGroup groupInteraction;
        private WorldToUIPoint uiInteraction;

        public bool isTalkingBefore { get; set; }

        public int itemCountCurrent { get; protected set; }
        public int itemCountNeed { get; private set; } = 10;

        private void Awake()
        {
            flowchart = GetComponent<Flowchart>();
            groupInteraction = GameObject.Find("群組_互動介面").GetComponent<CanvasGroup>();
            uiInteraction = GameObject.Find("群組_互動介面").GetComponent<WorldToUIPoint>();
            stateMachine = new StateMachine();
            questBefore = new NpcQuestBefore(this, stateMachine, "NPC 貓咪任務進行前");
            questing = new NpcQuesting(this, stateMachine, "NPC 貓咪任務進行中");
            questFinish = new NpcQuestFinish(this, stateMachine, "NPC 貓咪任務進行完成");
            stateMachine.DefaultState(questBefore);
        }
        private void Update()
        {
            stateMachine.UpdateState();
            //如果 玩家在範圍內 就要更新互動介面座標
            if (playerInArea) uiInteraction.UpdatePoint(transform, offsetInteraction);
#if UNITY_EDITOR
            Test_AdditemCount();
#endif
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                playerInArea = true;
                //先停止所有協同程序再啟動 避免錯誤
                StopAllCoroutines();
                StartCoroutine(FadeSystem.Fade(groupInteraction));
                //Debug.Log(collision.name);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (groupInteraction == null) return;
                playerInArea = false;
                StopAllCoroutines();
                StartCoroutine(FadeSystem.Fade(groupInteraction, false));
                //Debug.Log(collision.name);
                if (gameObject.activeInHierarchy) StartCoroutine(PlayerExit());
            }
        }
        //玩家離開

        /// <summary>
        /// 切換互動介面
        /// </summary>
        /// <param name="="fadeIn">是否要淡入</param>
        public void SwitchInteractionUI(bool fadeIn)
        {
            //如果此物件不在階層面板上(停止遊戲或被刪除時) 就跳出
            if (!gameObject.activeInHierarchy) return;
            //先停止所有協同程序再啟動 避免錯誤
            StopAllCoroutines();
            StartCoroutine(FadeSystem.Fade(groupInteraction, fadeIn));

        }

        private IEnumerator PlayerExit()
        {
            //等互動介面淡出
            yield return StartCoroutine(FadeSystem.Fade(groupInteraction, false));
            playerInArea = false;
        }
#if UNITY_EDITOR
        private void Test_AdditemCount()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                itemCountCurrent++;
                Debug.Log($"<color=#7f7>道具數量 {itemCountCurrent}</color>");
            }
        }
#endif
    }
}