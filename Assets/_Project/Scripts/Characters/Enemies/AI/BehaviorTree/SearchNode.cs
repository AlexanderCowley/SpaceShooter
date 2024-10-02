using UnityEngine;
using BehaviorTree;
public class SearchNode : Node
{
    //Detect if another enemy is in front of them
    //Kill enemy post charge
    Transform _transform;
    bool _playerDetected = false;

    Vector3 _halfBoxSize;
    public SearchNode(Transform transform, Vector3 boxHalfSize)
    {
        _transform = transform;
        _halfBoxSize = boxHalfSize;
    }

    public override NodeStatus Evaluate()
    {     
        if(_playerDetected) return NodeStatus.RUNNING;

        if(Physics.BoxCast(_transform.position, _halfBoxSize, _transform.forward * -1, out RaycastHit hit))
        {
            EnBT frontEnemy = hit.transform.GetComponent<EnBT>();
            Move temp = hit.transform.GetComponent<Move>();
            
            if(frontEnemy == null)
            {
                if(temp != null)
                {
                    _playerDetected = true;
                    Object.Destroy(_transform.gameObject, 0.8f);
                    return NodeStatus.SUCCESS;
                }
                return NodeStatus.FAILURE;
            }
        }
        return NodeStatus.FAILURE;
    }
}
