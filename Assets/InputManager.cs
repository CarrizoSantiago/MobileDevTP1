﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    static InputManager instance = null;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }

    public enum ButtonStates
    {
        Down,
        Up,
        Pressed,
        NoPressed
    }
    Dictionary<string, float> axisValues = new Dictionary<string, float>();
    Dictionary<string, ButtonStates> buttonsValues = new Dictionary<string, ButtonStates>();


    public void SetAxis(string axis, float value)
    {
        if (!axisValues.ContainsKey(axis))
            axisValues.Add(axis, value);
        axisValues[axis] = value;
    }
    float GetOrAddAxis(string axis)
    {
        if (!axisValues.ContainsKey(axis))
            axisValues.Add(axis, 0f);
        return axisValues[axis];
    }
    public float GetAxis(string axis)
    {
#if UNITY_EDITOR
        return GetOrAddAxis(axis) + Input.GetAxis(axis);
#elif UNITY_ANDROID || UNITY_IOS
        return  GetOrAddAxis(axis);
#elif UNITY_STANDALONE
        return  Input.GetAxis(axis);
#endif
    }
    public void SetButtonState(string button, ButtonStates state)
    {
        if (!buttonsValues.ContainsKey(button))
            buttonsValues.Add(button, state);
        buttonsValues[button] = state;
    }
    public bool GetButton(string button)
    {
#if UNITY_EDITOR
        return Input.GetButtonDown(button) || (GetOrAddButtonState(button) == ButtonStates.Pressed);
#elif UNITY_ANDROID || UNITY_IOS
        return  (GetOrAddButtonState(button) == ButtonStates.Pressed);
#elif UNITY_STANDALONE
        return  Input.GetButtonDown(button)
#endif
    }
    public bool GetButtonUp(string button)
    {
        //return Input.GetButton(button);
#if UNITY_EDITOR
        return Input.GetButton(button) || (GetOrAddButtonState(button) == ButtonStates.Up);
#elif UNITY_ANDROID || UNITY_IOS
        return  (GetOrAddButtonState(button) == ButtonStates.Up)
#elif UNITY_STANDALONE
        return  Input.GetButton(button)
#endif
    }
    public bool GetButtonDown(string button)
    {
        //return Input.GetButton(button);
#if UNITY_EDITOR
        return Input.GetButtonDown(button) || (GetOrAddButtonState(button) == ButtonStates.Down);
#elif UNITY_ANDROID || UNITY_IOS
        return (GetOrAddButtonState(button) == ButtonStates.Down);
#elif UNITY_STANDALONE
        return  Input.GetButtonDown(button)
#endif
    }
    ButtonStates GetOrAddButtonState(string button)
    {
        if (!buttonsValues.ContainsKey(button))
            buttonsValues.Add(button, ButtonStates.NoPressed);
        return buttonsValues[button];
    }

}
