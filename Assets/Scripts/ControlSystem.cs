using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.5f;
    [SerializeField, Range(0, 10)]
    private int jumpForce = 7;
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private Rigidbody2D rig;

    private void Awake()
    {
        Debug.Log("Hello World");
    }
    private void Start()
    {
        Debug.Log("<color=orange>開始事件</color>");
    }
    private void Update()
    {
        Debug.Log("<color=lime>更新事件</color>");
    }
}
    