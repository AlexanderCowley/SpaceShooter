using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    Button _firstButton;
    void Awake()
    {
        //Finds the first child with a button component
        int length = transform.childCount;
        for (int i = 0; i < length; i++)
        {
            if(!transform.GetChild(i).
                TryGetComponent<Button>(out _firstButton))
            {
                continue;
            }
            else
            {
                break;
            }
        }

        if(_firstButton == null)
        {
            Debug.LogError("First button could not be found!");
        }
    }

    void OnEnable() 
    {
        //Select First Button
        _firstButton.Select();
    }
}
