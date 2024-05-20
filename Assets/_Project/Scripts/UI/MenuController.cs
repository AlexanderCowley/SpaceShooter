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

    void OnEnable() 
    {
        _buttons[0].onClick.AddListener(SceneController.GoToTestScene);
        _buttons[2].onClick.AddListener(Application.Quit);
    }

    void OnDisable() 
    {
        _buttons[0].onClick.RemoveListener(SceneController.GoToTestScene);
        _buttons[2].onClick.RemoveListener(Application.Quit);
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

    void EnterSelection()
    {

    }

    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SelectedButton.onClick?.Invoke();
        }
        if(Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            NextButton();
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            PreviousButton();
        }
    }
}
