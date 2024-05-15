using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    GameObject _instance;
    void Awake()
    {
        CombatHealth.PlayerDeathHandler += KillCharacter;
    }

    //To prevent an error after destroying the gameobject
    void OnEnable() 
    {
        _instance = gameObject;
    }

    void KillCharacter()
    {
        Destroy(_instance, 0.25f);
    }
}
