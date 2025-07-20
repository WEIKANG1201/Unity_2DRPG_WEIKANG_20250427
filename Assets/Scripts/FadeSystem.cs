using System.Collections;
using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 學習協同程序 Coroutine
    /// 淡入淡出系統
    /// </summary>
    public class FadeSystem : MonoBehaviour
    {

        // static 讓該成員不須掛在物件上或實例化即可使用
        //使用方式:類別名稱 方法名稱 FadeSystem.Fade
        /// <summary>
        /// 淡入淡出
        /// </summary>
        /// <returns></returns>
        /// <param name="group">畫布群組元件</param>
        /// <param name="fadeIn">是否淡入</param>
        public static IEnumerator Fade(CanvasGroup group, bool fadeIn = true)
        {
            //增加值:是否淡入 是+0.1 否-0.1
            float increase = fadeIn ? +0.1f : -0.1f;

            //迴圈重複執行10次
            for (int i = 0; i < 10; i++)
            {
                //更新畫布群組 的 透明度 每次遞增
                group.alpha += increase;
                //等待 0.03 秒
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}