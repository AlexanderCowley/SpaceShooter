using UnityEngine;

public class CombatHealth : MonoBehaviour, IDamagable
{
    //plain c#?
    //inject data from stat holder
    [SerializeField] CombatStat healthStat;
    public CharacterType CharType = CharacterType.None;
    EnBT BT;

    public delegate void OnDeath(EnBT enBT);
    public event OnDeath DeathEventHandler;

    void Awake() 
    {
        BT = GetComponent<EnBT>();
    }

    public void TakeDamage(int damageTaken)
    {
        healthStat.StatValue -= damageTaken;

        if (healthStat.StatValue == 0)
            DeathEventHandler?.Invoke(BT);
        //Replace with CalculateDamageTaken(damageTaken)
    }

    int CalculateDamageTaken(int damageTaken)
    {
        int result = 0;

        return result;
    }
}