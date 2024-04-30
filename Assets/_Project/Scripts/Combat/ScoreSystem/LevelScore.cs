using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public static LevelScore Instance;
    public static int Score = 0;
    public static int HighScore = 0;
    public delegate void ScoreChangeHandler();
    public static event ScoreChangeHandler ScoreChangeEvent;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore(int newScore)
    {
        Score += newScore;
        ScoreChangeEvent.Invoke();
    }

    void UpdateHighScore(int newScore)
    {
        if(newScore > HighScore) 
            HighScore = Score;
    }
}
