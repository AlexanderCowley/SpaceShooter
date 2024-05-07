using UnityEngine;

public class CombatHealth : MonoBehaviour, IDamagable
{
    [SerializeField] CombatStat healthStat;
    public CharacterType CharType = CharacterType.None;
    EnBT BT;

    public delegate void OnDeath(EnBT enBT);
    public delegate void OnPlayerDeath();
    public event OnDeath DeathEventHandler;
    public static event OnPlayerDeath PlayerDeathHandler;


    void Awake() 
    {
        BT = GetComponent<EnBT>();
    }

    public void TakeDamage(int damageTaken)
    {
        healthStat.StatValue -= damageTaken;
        if(healthStat.StatValue <= 0)
        {
            if (BT != null)
                DeathEventHandler?.Invoke(BT);
            else
                PlayerDeathHandler?.Invoke();

        }
        //Replace with CalculateDamageTaken(damageTaken)
    }

    int CalculateDamageTaken(int damageTaken)
    {
        int result = 0;

        return result;
    }
}