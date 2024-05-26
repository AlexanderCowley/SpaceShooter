using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class SearchNode : Node
{
    //Detect if another enemy is in front of them
    //Raycast
    EnBT _enemyInFront;
    Transform _transform;
    public SearchNode(Transform transform)
    {
        _transform = transform;
    }

    public override NodeStatus Evaluate()
    {
        if(Physics.Raycast(_transform.position, _transform.forward, out RaycastHit hit))
        {
            _enemyInFront = hit.transform.GetComponent<EnBT>();
            if(_enemyInFront != null)
            {
                return NodeStatus.SUCCESS;
            }
        }
        return NodeStatus.RUNNING;
    }
}
