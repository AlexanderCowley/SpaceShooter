using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    Button[] _buttons;
    Button SelectedButton;
    int _buttonCount;
    int _currentIndex = 0;
    void Awake() 
    {
        _buttons = GetComponentsInChildren<Button>();
        _buttonCount = _buttons.Length;
        //Highlight new game
        SelectedButton = _buttons[0];
        SelectedButton.Select();
    }

    void ChangeButton()
    {
        SelectedButton = _buttons[_currentIndex];
        SelectedButton.Select();
    }

    void Update()
    {
        if(Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            _currentIndex = (_currentIndex + _buttonCount - 1) % _buttonCount;
            ChangeButton();
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            _currentIndex = (_currentIndex + 1) % _buttonCount;
            ChangeButton();
        }
    }
}
