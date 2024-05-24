using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public static int EnWave {get; private set;} = 0;
    public delegate void EnemyWavesChangedHandler();
    public static EnemyWavesChangedHandler EnemyWaveHandler;

    void Awake()
    {
        //Read from file
        //Reset wave count on load
        EnWave = 0;
    }

    public static void NextWave()
    {
        EnWave += 1;
        EnemyWaveHandler.Invoke();
    }

    void ReadFromFile()
    {
        //
    }
}
