using UnityEngine;

public class CombatHealth : MonoBehaviour, IDamagable
{
    [SerializeField] CombatStat healthStat;
    public CharacterType CharType = CharacterType.None;
    [Header("Debug Settings")]
    [SerializeField] bool IsInvincible;
    EnBT BT;

    public delegate void OnDeath(EnBT enBT);
    public delegate void OnPlayerDeath();
    public event OnDeath DeathEventHandler;
    public static event OnPlayerDeath PlayerDeathHandler;


    void Awake() 
    {
        BT = GetComponent<EnBT>();
        //Resets health
        healthStat.StatValue = healthStat.MaxValue;
    }

    public void TakeDamage(int damageTaken)
    {
        //For debugging
        if(IsInvincible) return;
        
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