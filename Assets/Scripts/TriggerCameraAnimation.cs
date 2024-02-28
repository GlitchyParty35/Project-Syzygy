using UnityEngine;

public class TriggerCameraAnimation : MonoBehaviour
{
    public Animator cameraAnimator; // 指向包含动画控制器的摄像机的引用

    void Update()
    {
        // 检测玩家是否按下了空格
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraAnimator.SetTrigger("moveForward");
        }
    }
}
