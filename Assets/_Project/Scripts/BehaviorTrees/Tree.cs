using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        //recursively contains entire tree
        Node _root = null;

        protected void Start() => _root = SetUpTree();
        protected abstract Node SetUpTree();
        void Update() => _root.Evaluate();
    }
}
