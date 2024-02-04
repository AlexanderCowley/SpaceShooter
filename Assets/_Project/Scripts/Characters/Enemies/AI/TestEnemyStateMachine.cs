using UnityEngine;

public class TestEnemyStateMachine : AbstractStateMachine
{
    void OnEnable()
    {
        ChangeState<FollowPlayer>();
    }
}