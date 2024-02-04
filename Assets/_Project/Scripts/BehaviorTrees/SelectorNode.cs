using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class SelectorNode : Node
    {
        public SelectorNode() : base() { }
        public SelectorNode(List<Node> children) : base(children) { }
        public override NodeStatus Evaluate()
        {
            for (int i = 0; i < Children.Count - 1; i++)
            {
                switch (Children[i].Evaluate())
                {
                    case NodeStatus.FAILURE:
                        continue;

                    case NodeStatus.SUCCESS:
                        _nodeStatus = NodeStatus.SUCCESS;
                        return _nodeStatus;

                    case NodeStatus.RUNNING:
                        _nodeStatus = NodeStatus.RUNNING;
                        return _nodeStatus;

                    default:
                        continue;
                }
            }
            _nodeStatus = NodeStatus.FAILURE;
            return _nodeStatus;
        }
    }

}