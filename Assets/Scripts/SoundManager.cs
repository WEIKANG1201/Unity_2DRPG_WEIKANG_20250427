using UnityEngine;

namespace WEIKANG
{
    /// <summary>
    /// 音效管理器
    /// </summary>
    /// RC 要求元件(元件類型) 套用腳本到物件時會自動賦予該元件
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;
        public static SoundManager instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<SoundManager>();
                return _instance;
            }
        }
        private AudioSource aud;
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }
    }
}