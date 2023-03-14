using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode jump { get; set; }
    public KeyCode interact { get; set; }

    private void Awake()
    {
        if (IM == null)
        {
            DontDestroyOnLoad(gameObject);
            IM = this;
        }
        else if (IM != this)
        {
            Destroy(gameObject);
        }

        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "N"));
    }

    public static void SetKeyCode(string inputName, KeyCode newKeyCode)
    {
        switch (inputName)
        {
            case "forward":
                IM.forward = newKeyCode;
                break;
            case "backward":
                IM.backward = newKeyCode;
                break;
            case "right":
                IM.right = newKeyCode;
                break;
            case "left":
                IM.left = newKeyCode;
                break;
            case "jump":
                IM.jump = newKeyCode;
                break;
            case "interact":
                IM.interact = newKeyCode;
                break;
            default:
                Debug.LogError("Invalid input name");
                break;
        }
    }
}
