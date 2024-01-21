using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectTweener : MonoBehaviour
{
    [SerializeField] bool hasStartTween; 
    [SerializeField] bool scaleDown;
    [SerializeField] bool scaleUp;
    [SerializeField] float animationTime = 1f;
    [SerializeField] Vector3 starttweenDirection;
    [SerializeField] Vector3 tweenDirection;

    [SerializeField] GameObject meshHolder;

    private void OnEnable()
    {
        if (!hasStartTween) return;
        ControlScaleUsingTweeningDownLocal(starttweenDirection);
    }

    public void DoTweenAnimation(Action callback)
    {
        if(scaleDown)
        {
            ControlScaleUsingTweeningDown(callback);
        }
    }

    void ControlScaleUsingTweeningDown(Action callback)
    {
        LeanTween.scale(meshHolder, tweenDirection, animationTime).setEaseInBounce().setOnComplete(() => callback.Invoke());            
    }

    void ControlScaleUsingTweeningDownLocal(Vector3 startTweenDirection)
    {
        LeanTween.scale(meshHolder, startTweenDirection, animationTime).setEaseInBounce();
    }
}
