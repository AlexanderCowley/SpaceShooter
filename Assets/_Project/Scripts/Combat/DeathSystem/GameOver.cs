using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas _gameOverCanvas;

    void Awake()
    {
        _gameOverCanvas = transform.GetChild(4).GetComponent<Canvas>();
        _gameOverCanvas.gameObject.SetActive(false);
    }
    void OnEnable() 
    {
        CombatHealth.PlayerDeathHandler += GameOverHandler;
    }

    void GameOverHandler()
    {
        _gameOverCanvas.gameObject.SetActive(true);
    }
}
