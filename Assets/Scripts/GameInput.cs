using UnityEngine;
using System.Collections.Generic;

public static class GameInput
{
    private static Dictionary<string, KeyCode> KeyboardControls;
    static GameInput()
    {
        KeyboardControls = new Dictionary<string, KeyCode>();
    }
    public static void EditControl(string controlName, KeyCode key)
    {
        if (KeyboardControls.ContainsKey(controlName))
        {
            KeyboardControls[controlName] = key;
        }
        else
        {
            KeyboardControls.Add(controlName, key);
        }
    }
    public static bool Down(string controlName)
    {
        return Input.GetKeyDown(KeyboardControls[controlName]);
    }
    public static bool Held(string controlName)
    {
        return Input.GetKey(KeyboardControls[controlName]);
    }
    public static bool Up(string controlName)
    {
        return Input.GetKeyUp(KeyboardControls[controlName]);
    }
}
