using UnityEngine;
[RequireComponent(typeof(CombatHealth))]
public class CharacterDeath : MonoBehaviour
{
    CombatHealth _combatHealth;
    void Awake()
    {
        _combatHealth = GetComponent<CombatHealth>();
        _combatHealth.DeathEventHandler += KillCharacter;
    }

    void KillCharacter()
    {
        Destroy(this.gameObject, 0.25f);
    }
}