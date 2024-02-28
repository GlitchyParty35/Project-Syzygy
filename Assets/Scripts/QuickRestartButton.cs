using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理的命名空间

public class QuickRestartButton : MonoBehaviour
{
    void Update()
    {
        // 检查玩家是否按下了'R'键
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }
    }

    void RestartCurrentScene()
    {
        // 获取并重新加载当前激活的场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 打印一条消息到控制台，确认场景正在重新加载
        Debug.Log("Scene reloaded successfully.");
    }
}
