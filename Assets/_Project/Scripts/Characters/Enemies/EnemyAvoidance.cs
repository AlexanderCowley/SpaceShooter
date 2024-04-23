using UnityEngine;
public class EnemyAvoidance : MonoBehaviour
{
    EnBT _bt;
    EnBT _enemyRight;
    EnBT _enemyLeft;
    void Awake() 
    {
        _bt = GetComponent<EnBT>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.TryGetComponent
            <EnBT>(out EnBT _enemy))
        {
            if(_enemyRight == null)
            {
                if(other.transform.position.x > transform.position.x)
                {
                    _enemyRight = _enemy;
                    _bt.AssignEnemy(_enemyRight, true);
                    return;
                }
            }
            if(_enemyLeft == null)
            {
                if(other.transform.position.x < transform.position.x)
                {
                    _enemyLeft = _enemy;
                    _bt.AssignEnemy(_enemyLeft, false);
                    return;
                }
            }
        }
    }
}
