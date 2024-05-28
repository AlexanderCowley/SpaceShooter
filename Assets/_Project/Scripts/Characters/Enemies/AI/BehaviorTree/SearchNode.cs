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
    bool _playerDetected = false;
    public SearchNode(Transform transform)
    {
        _transform = transform;
    }

    public override NodeStatus Evaluate()
    {
        //Debug.DrawRay(_transform.position, 
            //_transform.forward * 10f, Color.red);
        if(_playerDetected) return NodeStatus.RUNNING;

        if(Physics.Raycast(_transform.position, _transform.forward * -1, out RaycastHit hit))
        {
            EnBT frontEnemy = hit.transform.GetComponent<EnBT>();
            Move temp = hit.transform.GetComponent<Move>();
            
            if(frontEnemy == null)
            {
                if(temp != null)
                {
                    Debug.Log(temp);
                    _playerDetected = true;
                    return NodeStatus.SUCCESS;
                }
                return NodeStatus.FAILURE;
            }
        }
        return NodeStatus.FAILURE;
    }
}
