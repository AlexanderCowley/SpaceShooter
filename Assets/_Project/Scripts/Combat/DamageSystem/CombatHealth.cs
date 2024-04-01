using UnityEngine;

public class CombatHealth : MonoBehaviour, IDamagable
{
    //plain c#?
    //inject data from stat holder
    [SerializeField] CombatStat healthStat;
    public CharacterType CharType = CharacterType.None;

    public delegate void OnDeath();
    public event OnDeath DeathEventHandler;

    public void TakeDamage(int damageTaken)
    {
        healthStat.StatValue -= damageTaken;

        if (healthStat.StatValue == 0)
            DeathEventHandler?.Invoke();
        //Replace with CalculateDamageTaken(damageTaken)
    }

    int CalculateDamageTaken(int damageTaken)
    {
        int result = 0;

        return result;
    }
}