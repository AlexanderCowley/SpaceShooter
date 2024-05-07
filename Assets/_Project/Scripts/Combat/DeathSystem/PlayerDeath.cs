using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Awake()
    {
        CombatHealth.PlayerDeathHandler += KillCharacter;
    }

    void KillCharacter()
    {
        Destroy(gameObject, 0.25f);
    }
}
