using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class AvoidEnemyNode : Node
{
    //Enemy Range
    float Range;
    Transform _transform;
    //Dot Product
    public AvoidEnemyNode(Transform enemyTransform, float range)
    {
        this._transform = enemyTransform;
        this.Range = range;
    }
    public override NodeStatus Evaluate()
    {
        Transform target = (Transform)Parent.GetData("target");
        Vector2 newTarget = new(target.position.x, _transform.position.y);
        _transform.position = Vector2.MoveTowards(_transform.position, newTarget, 
        Time.deltaTime * Range);

        return NodeStatus.RUNNING;
    }
}
