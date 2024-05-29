using UnityEngine;
[RequireComponent(typeof(CombatHealth))]
public class EnemyDeath : MonoBehaviour
{
    CombatHealth _combatHealth;
    void Awake()
    {
        _combatHealth = GetComponent<CombatHealth>();
        _combatHealth.DeathEventHandler += KillCharacter;
    }

    protected virtual void KillCharacter(EnBT enemyInstance)
    {
        Destroy(gameObject, 0.25f);
    }
}