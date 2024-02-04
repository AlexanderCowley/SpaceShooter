using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class Node
    {
        //Needs access to node status, parent and children
        protected NodeStatus _nodeStatus;
        public Node Parent;
        protected List<Node> Children = new List<Node>();

        Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            Parent = null;
        }

        public Node(List<Node> children)
        {
            for (int i = 0; i < children.Count; i++)
                Attach(children[i]);
        }

        void Attach(Node node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        public virtual NodeStatus Evaluate() => _nodeStatus = NodeStatus.FAILURE;

        public void SetDataDictionary(string key, object data)
        {
            _dataContext[key] = data;
        }

        //Checks if the data neccessary is defined in the branch not just the node
        //applies recursion to check different branch conditions all the way to the root
        public object GetData(string key)
        {
            object data = null;

            if (_dataContext.TryGetValue(key, out data))
                return data;

            Node node = Parent;

            while (node != null)
            {
                data = node.GetData(key);
                if (data != null)
                    return data;

                node = node.Parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return false;
            }

            Node node = Parent;

            while (node != null)
            {
                bool isCleared = node.ClearData(key);
                if (isCleared)
                    return true;

                node = node.Parent;
            }
            return false;
        }
    }
}
