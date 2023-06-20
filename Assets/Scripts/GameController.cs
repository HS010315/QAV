using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TargetGenerator targetGenerator;
    public StartButton startButton;

    private void Start()
    {
        startButton.Initialize(targetGenerator);    }
}
