using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    void OnEnable() 
    {
        InitMenu();
    }

    void InitMenu()
    {
        //Highlight First Button
        SelectedButton = _buttons[0];
        SelectedButton.Select();
    }

    void NextButton()
    {
        _currentIndex = (_currentIndex + _buttonCount - 1) % _buttonCount;
        SelectedButton = _buttons[_currentIndex];
        SelectedButton.Select();
    }

    void PreviousButton()
    {
        _currentIndex = (_currentIndex + 1) % _buttonCount;
        SelectedButton = _buttons[_currentIndex];
        SelectedButton.Select();
    }
}
