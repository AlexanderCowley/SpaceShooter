using UnityEngine;

[CreateAssetMenu(menuName = "Characters/New Score Stat")]
public class ScoreObject : ScriptableObject
{
    [field: SerializeField] public int Score {get; private set;}
}
