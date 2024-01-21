using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeAmount;
    [SerializeField] float shakeTime;

    [ContextMenu("TestShake")]
    public void PerformCameraShake()
    {
        LeanTween.rotateAroundLocal(gameObject, transform.forward, shakeAmount, shakeTime).setEaseInOutSine().setLoopPingPong(3);
    }
}
