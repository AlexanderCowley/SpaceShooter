using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class FollowPlayerNode : Node
{
    Transform _transform;
    float Range;
    NavMeshAgent _agent;
    public FollowPlayerNode(Transform objectTransform, NavMeshAgent agent, float range)
    {
        this._transform = objectTransform;
        this._agent = agent;
        this.Range = range;
    }

    public override NodeStatus Evaluate()
    {
        Transform target = (Transform)Parent.GetData("target");
        Vector2 newTarget = new(target.position.x, _transform.position.y);
        _agent.destination = newTarget;
        _agent.isStopped = false;
        //_transform.position = Vector2.MoveTowards(_transform.position, newTarget, 
        //Time.deltaTime * Range);

        _nodeStatus = NodeStatus.RUNNING;
        return _nodeStatus;
    }
}