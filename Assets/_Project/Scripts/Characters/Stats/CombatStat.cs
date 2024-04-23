using UnityEngine;
[CreateAssetMenu(menuName = "Characters/New Combat Stat")]
public class CombatStat : ScriptableObject
{
    public delegate void OnValueChanged();
    public event OnValueChanged ValueChangedHandler;

    int statValue;
    [field: SerializeField] public int MinValue { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }

    public int StatValue
    {
        get => statValue;
        set
        {
            statValue = value;
            statValue = Mathf.Clamp(statValue, MinValue, MaxValue);
            ValueChangedHandler?.Invoke();
        }
    }

    void OnEnable() => statValue = MaxValue;
}