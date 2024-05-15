using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class RetryButton : MonoBehaviour
{
    InputAction _inputAction;

    Button _retryButton;

    void Awake() 
    {
        _retryButton = GetComponent<Button>();
    }

    void Update() 
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneController.GoToTestScene();
        }
    }
}
