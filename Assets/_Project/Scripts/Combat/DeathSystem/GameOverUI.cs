using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    TextMeshProUGUI _gameOverText;

    void Awake() 
    {
        _gameOverText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        _gameOverText.text = $"GAME OVER \n\nScore: {LevelScore.Score}";
    }
}
