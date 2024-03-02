using UnityEngine;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;
public class TestBehaviorTree : BehaviorTree.Tree
{
    [SerializeField] Transform _playerTransform;
    //Replace with Stat Holder Component
    [SerializeField] float Range;
    [SerializeField] TestBehaviorTree _testEnemy;
    NavMeshAgent _agent;
    Quaternion initialRotation;
    void Awake() 
    {
        initialRotation = transform.rotation;
        _agent = GetComponent<NavMeshAgent>();
    }
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            new AttackNode(this.transform),
            new OutOfRange(this.transform, _playerTransform, Range),
            new FollowPlayerNode(this.transform, _agent, Range)
        });
        return root;
    }
}