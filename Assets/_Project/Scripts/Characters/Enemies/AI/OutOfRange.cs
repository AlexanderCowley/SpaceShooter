using UnityEngine;
using BehaviorTree;

public class OutOfRange : Node
{
    Transform _transform;
    Transform _target;
    float Range;

    public OutOfRange(Transform objectTransform, Transform targetTransform, float range)
    {
        this._target = targetTransform;
        this._transform = objectTransform;
        this.Range = range;
    }

    public override NodeStatus Evaluate()
    {
        object targetObj = Parent.GetData("target");
        if(targetObj == null)
            Parent.SetDataDictionary("target", _target);

        _nodeStatus = DistanceFromTarget() ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        return _nodeStatus;
    }

    bool DistanceFromTarget()
    {
        float distanceFromTarget = Vector3.Distance(_target.position, _transform.position);
        return distanceFromTarget >= Range;
    }
}