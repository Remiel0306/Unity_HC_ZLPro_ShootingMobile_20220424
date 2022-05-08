using UnityEngine;

//�R�W�Ŷ�
namespace remiel
{
    /// <summary>
    /// ����t��:��ð����ʥ\��
    /// �����n�챱��}�Ⲿ��
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        [SerializeField, Header("�����n��")] private Joystick joystick;
        [SerializeField, Header("���ʳt��"), Range(0, 300)] private float speed = 3.5f;

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
            print("<color=yellow>����:" + joystick.Horizontal + "</color>");
        }

        private void Move()
        {
            //����.�[�t�� = �T���V�q(x,y,z)
            rigidBody.velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * speed;
        }
    }
}

