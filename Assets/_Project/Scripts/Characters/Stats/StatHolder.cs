using UnityEngine;

public class StatHolder : MonoBehaviour
{
    [SerializeField] CombatStat[] combatStats;
    public CombatStat[] CombatStats => combatStats;
}