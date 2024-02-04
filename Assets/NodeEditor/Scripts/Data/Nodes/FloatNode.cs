using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

[Serializable]
public class FloatNode : NodeBase
{
    public float NodeValue;
    NodeOutput output;

    public FloatNode()
    {
        output = new NodeOutput();
    }

    public override void InitNode()
    {
        base.InitNode();
        nodeType = NodeType.Float;
        NodeName = nodeType.ToString();
        NodeRect = new Rect(10f, 10f, 150f, 65f);
    }

    public override void UpdateNode(Event e, Rect viewRect)
    {
        base.UpdateNode(e, viewRect);
    }

#if UNITY_EDITOR
    public override void UpdateNodeGUI(Event e, Rect viewRect, GUISkin viewSkin)
    {
        base.UpdateNodeGUI(e, viewRect, viewSkin);
        if(GUI.Button(new Rect(NodeRect.x + NodeRect.width, NodeRect.y + (NodeRect.height * 0.5f) -12f, 24f, 24f), "", 
            viewSkin.GetStyle("NodeOutput")))
        {
            //Clicked on output node
            if(ParentGraph != null)
            {
                ParentGraph.wantsConnection = true;
                ParentGraph.connectionNode = this;
            }
        }
    }

    public override void DrawNodeProperties()
    {
        base.DrawNodeProperties();
        NodeValue = EditorGUILayout.FloatField("Float Value: ", NodeValue);
    }

#endif
}