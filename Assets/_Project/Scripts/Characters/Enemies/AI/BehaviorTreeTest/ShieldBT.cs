using UnityEngine;
using System.Collections.Generic;
using BehaviorTree;
public class ShieldBT : EnBT
{
    [SerializeField] float Range;
    FollowPlayerNode _followPlayerNode;
    protected override Node SetUpTree()
    {
        _followPlayerNode = new FollowPlayerNode(transform, Range);
        Node root = new SequenceNode(new List<Node>()
        {
            new OutOfRange(this.transform, _playerTransform, Range),
            _followPlayerNode
        });
        return root;
    }
    public void AssignEnemy(ShieldBT enemy, bool isRight) =>
        _followPlayerNode.AssignBlockEnemy(enemy, isRight);
}