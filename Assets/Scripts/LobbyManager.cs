using UnityEngine;

/// <summary>
/// �j�U�޲z��
/// ���a���U��ԫ��s��}�l�ǰt�ж�
/// </summary>
public class LobbyManager : MonoBehaviour
{
    [SerializeField, Header("�s�u���e��")]private GameObject goConnectView;

    //�����s��{�����q���y�{
    // 1.���Ѥ��}����k
    // 2. ���s�b�I����]�w�I�s����k

    public void StartConnect()
    {
        print("�}�l�s�u...");

        goConnectView.SetActive(true);
    }
}
