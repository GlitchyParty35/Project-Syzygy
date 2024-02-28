using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间
using System.Collections; // 引入协程支持

public class PlayAnimationAndLoadSceneOnEscWithDelay : MonoBehaviour
{
    public Animator cameraAnimator; // 指向包含动画控制器的摄像机的引用

    void Update()
    {
        // 检测玩家是否按下了Esc键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 触发动画
            cameraAnimator.SetTrigger("moveBack");
            // 开始计时两秒后跳转场景的协程
            StartCoroutine(LoadSceneAfterDelay("Main", 2f));
        }
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        // 等待指定的延迟时间
        yield return new WaitForSeconds(delay);
        // 加载指定场景
        SceneManager.LoadScene(sceneName);
    }
}


