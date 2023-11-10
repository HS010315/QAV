using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Restart : MonoBehaviour
{
   
    private void Update()
    {
        if (InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondaryButton, out bool yButtonState) && yButtonState)
        {
            SceneManager.LoadScene("Map Setting");
        }
    }
}
