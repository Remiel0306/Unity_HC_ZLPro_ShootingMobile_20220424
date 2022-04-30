using UnityEngine;

/// <summary>
/// 大廳管理器
/// 玩家按下對戰按鈕後開始匹配房間
/// </summary>
public class LobbyManager : MonoBehaviour
{
    [SerializeField, Header("連線中畫面")]private GameObject goConnectView;

    //讓按鈕跟程式溝通的流程
    // 1.提供公開的方法
    // 2. 按鈕在點擊後設定呼叫此方法

    public void StartConnect()
    {
        print("開始連線...");

        goConnectView.SetActive(true);
    }
}
