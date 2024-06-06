using UnityEngine;

public class Hitbox : MonoBehaviour
{
    CombatHealth _health;
    [SerializeField] int Damage;
    void OnTriggerEnter(Collider other) 
    {
        _health = other.GetComponent<CombatHealth>();
        if(_health != null && _health.CharType == CharacterType.Player)
        {
            _health.TakeDamage(Damage);
        }
    }
}
