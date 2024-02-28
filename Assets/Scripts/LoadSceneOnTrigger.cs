using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class LoadSceneOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 检查触发事件的对象是否有标签“Glass”
        if (other.gameObject.tag == "Glass")
        {
            Debug.Log("碰撞到了玻璃");
            // 加载名为“Map”的场景
            SceneManager.LoadScene("Map");
        }
    }
}

