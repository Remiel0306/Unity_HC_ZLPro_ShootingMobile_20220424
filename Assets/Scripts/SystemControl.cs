using UnityEngine;

//命名空間
namespace remiel
{
    /// <summary>
    /// 控制系統:荒野亂鬥移動功能
    /// 虛擬搖桿控制腳色移動
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        [SerializeField, Header("虛擬搖桿")] private Joystick joystick;
        [SerializeField, Header("移動速度"), Range(0, 300)] private float speed = 3.5f;

        private Rigidbody rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            GetJoystickValue();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GetJoystickValue()
        {
            print("<color=yellow>水平:" + joystick.Horizontal + "</color>");
        }

        private void Move()
        {
            //剛體.加速度 = 三維向量(x,y,z)
            rigidBody.velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * speed;
        }
    }
}

