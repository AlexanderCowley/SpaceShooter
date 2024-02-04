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
        _transform.position = Vector2.MoveTowards(_transform.position, target.position, Time.deltaTime * Range);

        _nodeStatus = NodeStatus.RUNNING;
        return _nodeStatus;
    }
}