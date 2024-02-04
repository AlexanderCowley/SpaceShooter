using UnityEngine;
[RequireComponent(typeof(PickUp))]
public class StatBoost : MonoBehaviour
{
    [SerializeField] CombatStat Stat;
    [SerializeField] int ValueToAdd;

    PickUp _pickUp;

    void OnEnable()
    {
        _pickUp = GetComponent<PickUp>();
        _pickUp.PickUpHandler += Effect;
    }

    void Effect(Collider collider) => Stat.StatValue += ValueToAdd;
}