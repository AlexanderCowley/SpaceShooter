using UnityEngine;

public class HeatCost : MonoBehaviour, IHeatable
{
    [SerializeField] CombatStat heatValue;
    public void OnHeatUse(int heatCost)
    {
        heatValue.StatValue -= heatCost;
    }
}