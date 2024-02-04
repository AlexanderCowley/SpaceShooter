using UnityEngine;

public class FollowPlayer : MonoBehaviour, IState
{
    [SerializeField] Transform _target;
    TestEnemyStateMachine stateMachine;

    [SerializeField] float Range;
    [SerializeField] float Speed;
    public void OnStateEntered()
    {
        stateMachine = GetComponent<TestEnemyStateMachine>();
    }

    bool DistranceFromTarget()
    {
        float distanceFromTarget = Vector3.Distance(_target.position, this.transform.position);
        return distanceFromTarget <= Range;
    }

    public void OnStateExecute()
    {
        if (!DistranceFromTarget())
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * Range);
    }

    public void OnStateExit()
    {
        stateMachine = null;
    }
}