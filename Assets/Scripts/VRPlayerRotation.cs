using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public XRController controller;

    private void Update()
    {
        // ��Ʈ�ѷ��� �Է� ���� �����ɴϴ�.
        Vector2 joystickValue = GetJoystickInput();

        // ���� �������� ȸ���մϴ�.
        RotatePlayer(joystickValue.x);
    }

    private Vector2 GetJoystickInput()
    {
        // VR ������ ��Ʈ�ѷ��� �Է� ���� �����ɴϴ�.
        InputDevice device = controller.inputDevice;
        Vector2 joystickValue;

        // ��Ʈ�ѷ��� ���̽�ƽ �Է� ���� �����ɴϴ�.
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue);

        return joystickValue;
    }

    private void RotatePlayer(float rotationAmount)
    {
        // �÷��̾ �־��� ȸ�� �ӵ��� ȸ����ŵ�ϴ�.
        transform.Rotate(Vector3.up, rotationAmount * rotationSpeed);
    }
}