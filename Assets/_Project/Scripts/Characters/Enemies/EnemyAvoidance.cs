using UnityEngine;
public class EnemyAvoidance : MonoBehaviour
{
    ShieldBT _bt;
    ShieldBT _enemyRight;
    ShieldBT _enemyLeft;
    void Awake() 
    {
        _bt = GetComponentInParent<ShieldBT>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.parent is null) return;
        if(other.transform.parent.gameObject.
        TryGetComponent<ShieldBT>(out ShieldBT _enemy))
        {
            if(_enemyRight == null)
            {
                if(other.transform.position.x > transform.position.x)
                {
                    _enemyRight = _enemy;
                    _bt.AssignEnemy(_enemyRight, true);
                }
            }
            if(_enemyLeft == null)
            {
                if(other.transform.position.x < transform.position.x)
                {
                    _enemyLeft = _enemy;
                    _bt.AssignEnemy(_enemyLeft, false);
                }
            }
        }
    }
}
