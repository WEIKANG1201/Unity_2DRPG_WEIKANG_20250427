using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("基本資料")]
    [SerializeField, Range(0, 10)]
    private float moveSpeed = 3.5f;
    [SerializeField, Range(0, 20)]
    private int jumpForce = 7;
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private Rigidbody2D rig;
    [Header("檢查地板資料")]
    [SerializeField]
    private Vector3 checkGroundSize = Vector3.one;
    [SerializeField]
    private Vector3 checkGroundOffset;
    [SerializeField]
    private LayerMask layerCanJump;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.6f, 0.7f, .06f);
        Gizmos.DrawCube(transform.position + checkGroundOffset, checkGroundSize);
    }



    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //Debug.Log($"<color=#f36>水平值:{h}</color>");


        rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);

       
        ani.SetFloat("移動", Mathf.Abs(h));

        bool isGrounded = Physics2D.OverlapBox(transform.position + checkGroundOffset,
            checkGroundSize, 0, layerCanJump);
        ani.SetBool("是否在地板上", isGrounded);
        ani.SetFloat("重力", rig.velocity.y);

        //Debug.Log($"<color=#f33>是否碰到地板:{isGrounded}</color>");

      

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) rig.velocity = new(0, jumpForce);

        if (Mathf.Abs(h) < 0.1f) return;
        

        float angle = h > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}
    