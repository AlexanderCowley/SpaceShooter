using UnityEngine;
using UnityEngine.AI;
public class EnemyAvoidance : MonoBehaviour
{
    TestBehaviorTree _bt;
    TestBehaviorTree _enemyRight;
    TestBehaviorTree _enemyLeft;
    Vector3 Dir;
    void Awake() 
    {
        _bt = GetComponentInParent<TestBehaviorTree>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.parent is null) return;
        if(other.transform.parent.gameObject.
        TryGetComponent<TestBehaviorTree>(out TestBehaviorTree _enemy))
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
