using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.UIElements;

public class InputSwitcher : MonoBehaviour
{
    TextMeshProUGUI btnText;

    [SerializeField] TextMeshProUGUI forwardText;
    [SerializeField] TextMeshProUGUI backwardText;
    [SerializeField] TextMeshProUGUI rightText;
    [SerializeField] TextMeshProUGUI leftText;
    [SerializeField] TextMeshProUGUI jumpText;
    [SerializeField] TextMeshProUGUI interactText;

    private void Start()
    {
        forwardText.text = InputManager.IM.forward.ToString();
        backwardText.text = InputManager.IM.backward.ToString();
        leftText.text = InputManager.IM.left.ToString();
        rightText.text = InputManager.IM.right.ToString();
        jumpText.text = InputManager.IM.jump.ToString();
        interactText.text = InputManager.IM.interact.ToString();
    }

    public void GetButtonText(TextMeshProUGUI text)
    {
        btnText = text;
    }

    public void WaitForKeyPress(string inputName)
    {
        StartCoroutine(WaitForKeyPressCoroutine(inputName, btnText));
    }

    IEnumerator WaitForKeyPressCoroutine(string inputName, TextMeshProUGUI keyText)
    {
        KeyCode newKeyCode = KeyCode.None;
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                newKeyCode = vKey;
                Debug.Log(newKeyCode);
                break;
            }
        }

        if (newKeyCode != KeyCode.None)
        {
            InputManager.SetKeyCode(inputName, newKeyCode);
            keyText.text = newKeyCode.ToString();
        }
    }

    private void UpdateText(string inputName, KeyCode newKeyCode)
    {
        switch (inputName)
        {
            case "forward":
                if (forwardText != null)
                    forwardText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("forwardKey", newKeyCode.ToString());
                break;
            case "backward":
                if (backwardText != null)
                    backwardText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("backwardKey", newKeyCode.ToString());
                break;
            case "right":
                if (rightText != null)
                    rightText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("rightKey", newKeyCode.ToString());
                break;
            case "left":
                if (leftText != null)
                    leftText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("leftKey", newKeyCode.ToString());
                break;
            case "jump":
                if (jumpText != null)
                    jumpText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("jumpKey", newKeyCode.ToString());
                break;
            case "interact":
                if (interactText != null)
                    interactText.text = newKeyCode.ToString();
                PlayerPrefs.SetString("interactKey", newKeyCode.ToString());
                break;
        }
    }
}