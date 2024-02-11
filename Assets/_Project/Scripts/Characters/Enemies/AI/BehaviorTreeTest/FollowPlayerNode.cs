using UnityEngine;
using BehaviorTree;

public class FollowPlayerNode : Node
{
    Transform _transform;
    float Range;
    public FollowPlayerNode(Transform objectTransform, float range)
    {
        this._transform = objectTransform;
        this.Range = range;
    }

    public override NodeStatus Evaluate()
    {
        Transform target = (Transform)Parent.GetData("target");
        Vector2 newTarget = new(target.position.x, _transform.position.y);
        _transform.position = Vector2.MoveTowards(_transform.position, newTarget, 
        Time.deltaTime * Range);

        _nodeStatus = NodeStatus.RUNNING;
        return _nodeStatus;
    }
}