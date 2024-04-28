using TMPro;
using UnityEngine;

public class EnemyWaveUI : MonoBehaviour
{
    TextMeshProUGUI _waveText;

    void Awake() 
    {
        _waveText = GetComponent<TextMeshProUGUI>();
        _waveText.text = $"Enemy Wave: {EnemyWaves.EnWave}";
    }

    void OnEnable() 
    {
        EnemyWaves.EnemyWaveHandler += UpdateEnemyWave;
    }

    void UpdateEnemyWave()
    {
        _waveText.text = $"Enemy Wave: {EnemyWaves.EnWave}";
    }
}
