using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float sensitivity = 100f; // 鼠标移动的灵敏度

    private float xRotation = 0f; // 摄像机的垂直旋转角度（上下查看）

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 锁定光标到屏幕中心，隐藏光标
    }

    void Update()
    {
        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // 计算新的垂直旋转角度，但不让摄像机翻转
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 应用垂直旋转（仅旋转摄像机）
        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, 0f);

        // 应用水平旋转（旋转摄像机）
        transform.Rotate(Vector3.up * mouseX);
    }
}


