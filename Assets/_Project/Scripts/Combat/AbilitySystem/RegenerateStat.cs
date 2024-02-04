using UnityEngine;
using System.Collections;

public class RegenerateStat : MonoBehaviour
{
    [Header("Stat to Regenerate")]
    [SerializeField] CombatStat combatStat;

    [Header("Value Per Tic")]
    [SerializeField] int incrementPerTic;

    [Header("Delay Values")]
    [SerializeField] float delayBeforeRegen;
    [SerializeField] float tic;

    bool isRegen = false;

    void OnEnable()
    {
        combatStat.ValueChangedHandler += OnStatChange;
    }

    void OnStatChange()
    {
        if (combatStat.StatValue == combatStat.MaxValue || isRegen == true)
            return;

        StartCoroutine(RegenStat());
    }

     IEnumerator RegenStat()
    {
        isRegen = true;
        yield return new WaitForSeconds(delayBeforeRegen);

        while (combatStat.StatValue != combatStat.MaxValue)
        {
            combatStat.StatValue += incrementPerTic;
            yield return new WaitForSeconds(tic);
        }

        isRegen = false;
        yield return null;
    }
}