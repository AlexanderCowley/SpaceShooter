using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class SequenceNode : Node
    {
        public SequenceNode() : base(){ }
        public SequenceNode(List<Node> children) : base(children) { }
        public override NodeStatus Evaluate()
        {
            bool anyChildRunning = false;

            for (int i = 0; i < Children.Count; i++)
            {
                switch (Children[i].Evaluate())
                {
                    case NodeStatus.FAILURE:
                        _nodeStatus = NodeStatus.FAILURE;
                        return _nodeStatus;

                    case NodeStatus.SUCCESS:
                        continue;

                    case NodeStatus.RUNNING:
                        anyChildRunning = true;
                        continue;

                    default:
                        _nodeStatus = NodeStatus.SUCCESS;
                        return _nodeStatus;
                }
            }
            _nodeStatus = anyChildRunning ? NodeStatus.RUNNING : NodeStatus.SUCCESS;
            return _nodeStatus;
        }
    }
}
