using Photon.Pun;
using UnityEngine;

//�R�W�Ŷ�
namespace remiel
{
    /// <summary>
    /// ����t��:��ð����ʥ\��
    /// �����n�챱��Ⲿ��
    /// </summary>
    public class SystemControl : MonoBehaviourPun
    {
        [SerializeField, Header("�����n��")] private Joystick joystick;
        [SerializeField, Header("���ʳt��"), Range(0, 300)] private float speed = 3.5f;
        [SerializeField, Header("�����V�ϥ�")] private Transform traDirectionIcon;
        [SerializeField, Header("�����V�ϥܽd��"), Range(0, 5)] private float rangeOirectionIcon = 2.5f;
        [SerializeField, Header("�������t��"), Range(0, 100)] private float speedTurn = 1.5f;
        [SerializeField, Header("�ʵe�Ѽƨ���")] private string parameterWalk;
        [SerializeField, Header("�e��")] private GameObject goCanvas;
        [SerializeField, Header("�e�����a��T")] private GameObject goCanvasPlayerInfo;
        [SerializeField, Header("�����V�ϥ�")] private GameObject goDirection;


        private Rigidbody rigidBody;
        private Animator animator;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            if (photonView.IsMine)
            {
                Instantiate(goCanvas);
                Instantiate(goCanvasPlayerInfo);
                Instantiate(goDirection);
            }
        }

        private void Update()
        {
            LookDirectionIconPos();
            UpdateDirectionPos();
            UpdateAnimation();
        }

        private void FixedUpdate()
        {
            Move();
            GetJoystickValue();
        }
            
        private void GetJoystickValue()
        {
            print("<color=yellow>����:" + joystick.Horizontal + "</color>");
        }

        private void Move()
        {
            // ����.�[�t�� = �T���V�q(x,y,z)
            rigidBody.velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * speed;
        }

        // ��s�����V�ϥܪ��y��
        private void UpdateDirectionPos()
        {
            // �s�y�� = ���⪺�y�� + �T���V�q(�����n�쪺�����P���� * ��V�ϥܪ��d��)
            Vector3 pos = transform.position + new Vector3(joystick.Horizontal, 0, joystick.Vertical)*rangeOirectionIcon;
            // ��s��V�ϥܪ��y�� = �s�@��
            traDirectionIcon.position = pos;
        }

        private void LookDirectionIconPos()
        {
            // ���o���ۨ��׸�T = �|�줸.���ۨ���(��V�ϥ� - ����) - ��V�ϥܻP���⪺�V�q
            Quaternion look = Quaternion.LookRotation(traDirectionIcon.position - transform.position);
            // ���⪺���� = �|�줸.����(���⪺����.�q������. ����t�� * �@�V���ɶ�)
            transform.rotation = Quaternion.Lerp(transform.rotation, look, speedTurn * Time.deltaTime);
            //���⪺�کԨ��� = �T���V�q(0, �쥻���کԨ���y , 0)nh
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        private void UpdateAnimation()
        {
            // �O�_�]�B = �����n��.����.�����s �� ���� �����s
            bool run = joystick.Horizontal != 0 || joystick.Vertical != 0;
            animator.SetBool(parameterWalk, run);
        }
    }
}

