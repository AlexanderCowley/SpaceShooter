using BehaviorTree;
using UnityEngine;

public class AttackNode : Node
{
    Transform _self;
    Transform _firePoint;
    int _attackSpeed;
    int _fireRate;
    TestEnemyWeapon _weapon;
    public AttackNode(Transform self)
    {
        this._self = self;
    }

    public override NodeStatus Evaluate()
    {
        _weapon = _self.gameObject.GetComponentInChildren<TestEnemyWeapon>();
        _weapon.Fire();
        _nodeStatus = NodeStatus.SUCCESS;
        return _nodeStatus;
    }
}