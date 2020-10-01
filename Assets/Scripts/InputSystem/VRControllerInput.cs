using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class VRControllerInput : MonoBehaviour
{
    //这个组件在XR Rig里的手柄上
    private XRController controller;
    private bool triggerButton = false, menuButton = false, GripButton = false, padButton = false;
    public float triggerPressValue;
    public InputDeviceCharacteristics controlNode;
    public Vector2 position;

    [Header("MenuButton")]
    public UnityEvent MenuOnHold;
    public UnityEvent MenuPressedOnce;
    public UnityEvent MenuOnRelease;

    [Header("TriggerButton")]
    public UnityEvent TriggerOnHold;
    public UnityEvent TriggerPressedOnce;
    public UnityEvent TriggerReleased;
    public Action<float> CarMovement;

    [Header("PadButton")]
    public UnityEvent padPressedOnce;
    public UnityEvent padOnHold;
    public Action<float, float> CharacterMovement;

    [Header("GripButton")]
    public UnityEvent gripOnHold;
    public UnityEvent gripPressedOnce;
    public UnityEvent gripReleased;

    private void Awake()
    {
        controller = GetComponent<XRController>();
    }
    private void Update()
    {
        MenuButtonFunction();
        GripButtonFunction();
        PadFunction();
    }
    private void FixedUpdate()
    {
        TriggerButtonFunction();
    }
    private void MenuButtonFunction()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool _menu))
        {
           
            if (_menu) // 按住按键
            {
                MenuOnHold.Invoke();

                if (!menuButton) // 按下按键
                {
                    MenuPressedOnce.Invoke();
                    menuButton = true;
                }
            }
            else // 抬起按键
            {
                if (menuButton)
                {
                    MenuOnRelease.Invoke();
                    menuButton = false;
                }
            }
        }
    }
    private void TriggerButtonFunction()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool _triggered))
        {
            if (_triggered) // 按住按键
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float value))
                {
                    TriggerOnHold.Invoke();
                    triggerPressValue = value;
                    if (CarMovement != null) CarMovement(value);
                }
                if (!triggerButton) // 按下按键
                {
                    TriggerPressedOnce.Invoke();
                    triggerButton = true;
                }

            }
            else // 抬起按键
            {
                triggerButton = false;
                triggerPressValue = 0;
                if (CarMovement != null) CarMovement(0);
                TriggerReleased.Invoke();
            }
        }
    }
    private void GripButtonFunction()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool _gripped))
        {
            if (_gripped) // 按住按键
            {
                gripOnHold.Invoke();
                if (!GripButton) // 按下按键
                {
                    gripPressedOnce.Invoke();
                    GripButton = true;
                }
            }
            else // 抬起按键
            {
                gripReleased.Invoke();
                GripButton = false;
            }
        }
    }
    private void PadFunction()
    {

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool _padClicked))
        {
            if (_padClicked) // 按住按键
            {
                padOnHold.Invoke();
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 _position))
                {
                    position = _position;
                    if (CharacterMovement != null) CharacterMovement(position.x, position.y);
                }

                if (!padButton) // 按下按键
                {
                    padPressedOnce.Invoke();
                    padButton = true;
                }
            }
            else // 抬起按键
            {
                padButton = false;
                position = Vector2.zero;
            }
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool _touched))
        {
            if (_touched) // 按住按键
            {

            }
            else
            {

            }
        }
    }
}
