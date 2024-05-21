using UnityEngine;
using UnityEngine.InputSystem;
public class RetryButton : MonoBehaviour
{

    void Update() 
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneController.GoToTestScene();
        }
    }
}
