using TMPro;
using UnityEngine;

public class KeybindChanger : MonoBehaviour
{
    public TMP_Text keybindText;
    private bool waitingForKey = false;

    private void Start()
    {
        UpdateKeybindText();
    }

    private void Update()
    {
        if (!waitingForKey || !Input.anyKeyDown) return;
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (!Input.GetKeyDown(keyCode)) continue;
            SetKeybind(keyCode);
            break;
        }
    }

    public void OnChangeKeybindButtonClicked()
    {
        waitingForKey = true;
    }

    private void SetKeybind(KeyCode newKey)
    {
        StaticData.DimensionSwitchKey = newKey;
        waitingForKey = false;
        UpdateKeybindText();
    }

    private void UpdateKeybindText()
    {
        keybindText.text = StaticData.DimensionSwitchKey.ToString();
    }
}