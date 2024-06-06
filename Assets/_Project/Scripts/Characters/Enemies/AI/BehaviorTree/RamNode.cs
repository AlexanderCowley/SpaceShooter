using UnityEngine;
using BehaviorTree;

public class RamNode : Node
{
    //Rush the player
    //Kill enemy outside of camera view
    BullDeath _bullDeath;
    float _enemySpeed;
    Transform _transform;
    Vector3 _target;
    bool _chargeStarted = false;
    Hitbox _hitbox;
    public RamNode(Transform transform, float enemySpeed, Hitbox hb)
    {
        _transform = transform;
        _enemySpeed = enemySpeed;
        _hitbox = hb;
        //Set target to bottom of the screen
        _target = _transform.position + new Vector3(0f, 0f, -10f);
        _bullDeath = _transform.GetComponent<BullDeath>();
    }

    public override NodeStatus Evaluate()
    {
        //Sets timer to true to trigger the event for bull charges
        if(!_chargeStarted)
        {
            _bullDeath.TimerIsActive = true;
            _chargeStarted = true;
        }
        //Movement logic
        _transform.position = Vector3.MoveTowards(_transform.position, 
          _target, Time.deltaTime * _enemySpeed);
        return NodeStatus.RUNNING;
    }
}
