using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Movement : MonoBehaviour
{
    public XRController controller = null;
    private CharacterController character;
    private GameObject _camera;
    private void Awake()
    {
        character = GetComponent<CharacterController>();
        _camera = GetComponent<XRRig>().cameraGameObject;
    }

    private void Update()
    {
        CommonInput();
    }

    private void CommonInput()
    {
        // Touchpad/Joystick position
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            var inputVector = new Vector3(position.x, Physics.gravity.y, z: position.y);
            var inputDirection = transform.TransformDirection(inputVector);
            var lookDirection = new Vector3(x: 0, _camera.transform.eulerAngles.y, z: 0);
            var newDirection = Quaternion.Euler(lookDirection) * inputDirection;
            character.Move(motion: newDirection * Time.deltaTime * 1f);
        }
    }
}