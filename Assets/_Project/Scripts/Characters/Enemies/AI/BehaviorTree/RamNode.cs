using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class RamNode : Node
{
    //Success
    //Move enemy straight on
    //Increase speed
    //Kill enemy outside of camera view
    float _enemySpeed;
    Transform _transform;
    Vector3 _target;
    public RamNode(Transform transform, float enemySpeed)
    {
        _transform = transform;
        _enemySpeed = enemySpeed;
        //Set target to bottom of the screen
        _target = _transform.position + new Vector3(0f, 0f, -10f);
    }

    public override NodeStatus Evaluate()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, 
          _target, Time.deltaTime * _enemySpeed);
        return NodeStatus.RUNNING;
    }
}
