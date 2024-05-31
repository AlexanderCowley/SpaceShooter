using BehaviorTree;
using UnityEngine;

public class AttackNode : Node
{
    Transform _self;
    Transform _firePoint;
    int _attackSpeed;
    int _fireRate;
    BasicEnemyWeapon _weapon;
    public AttackNode(Transform self)
    {
        _self = self;
    }

    public override NodeStatus Evaluate()
    {
        _weapon = _self.gameObject.GetComponentInChildren<BasicEnemyWeapon>();
        _weapon.Fire();
        _nodeStatus = NodeStatus.SUCCESS;
        return _nodeStatus;
    }
}