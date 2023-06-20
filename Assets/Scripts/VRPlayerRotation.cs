using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public XRController controller;

    private void Update()
    {
        // 컨트롤러의 입력 값을 가져옵니다.
        Vector2 joystickValue = GetJoystickInput();

        // 수평 방향으로 회전합니다.
        RotatePlayer(joystickValue.x);
    }

    private Vector2 GetJoystickInput()
    {
        // VR 오른손 컨트롤러의 입력 값을 가져옵니다.
        InputDevice device = controller.inputDevice;
        Vector2 joystickValue;

        // 컨트롤러의 조이스틱 입력 값을 가져옵니다.
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue);

        return joystickValue;
    }

    private void RotatePlayer(float rotationAmount)
    {
        // 플레이어를 주어진 회전 속도로 회전시킵니다.
        transform.Rotate(Vector3.up, rotationAmount * rotationSpeed);
    }
}