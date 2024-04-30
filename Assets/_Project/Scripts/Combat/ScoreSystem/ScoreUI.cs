using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _waveText;

    void Awake() 
    {
        _waveText = GetComponent<TextMeshProUGUI>();
        _waveText.text = $"Score: {LevelScore.Score}";
    }

    void OnEnable() 
    {
        LevelScore.ScoreChangeEvent += UpdateScore;
    }

    void OnDisable() 
    {
        LevelScore.ScoreChangeEvent -= UpdateScore;
    }

    void UpdateScore()
    {
        _waveText.text = $"Score: {LevelScore.Score}";
    }
}
