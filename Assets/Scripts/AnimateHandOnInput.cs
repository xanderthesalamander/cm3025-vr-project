using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    // Pinch action is connected to the input action
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    // It will be used to update the hand animator
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Get value of the trigger and update the animator
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        // Get value of the grip and update the animator
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
