using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

[Serializable]
public class AddNode : NodeBase
{
    public float NodeSum;
    public NodeOutput output;
    public NodeInput inputA;
    public NodeInput inputB;
    public AddNode()
    {
        output = new NodeOutput();
        inputA = new NodeInput();
        inputB = new NodeInput();
    }
    public override void InitNode()
    {
        base.InitNode();
        nodeType = NodeType.Add;
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
        if (GUI.Button(new Rect(NodeRect.x + NodeRect.width, NodeRect.y + (NodeRect.height * 0.5f) - 12f, 24f, 24f), "",
            viewSkin.GetStyle("NodeOutput")))
        {
            //Clicked on output node
            if (ParentGraph != null)
            {
                ParentGraph.wantsConnection = true;
                ParentGraph.connectionNode = this;
            }
        }

        if (GUI.Button(new Rect(NodeRect.x - 24f, (NodeRect.y + (NodeRect.height * 0.33f) - 14f), 24f, 24f), "",
            viewSkin.GetStyle("NodeOutput")))
        {
            inputA.inputNode = ParentGraph.connectionNode;
            inputA.isOccupied = inputA.inputNode != null ? true : false;

            ParentGraph.wantsConnection = false;
            ParentGraph.connectionNode = null;
        }

        if (GUI.Button(new Rect(NodeRect.x - 24f, ((NodeRect.y + (NodeRect.height * 0.33f) * 2) - 8f), 24f, 24f), "",
            viewSkin.GetStyle("NodeOutput")))
        {
            inputB.inputNode = ParentGraph.connectionNode;
            inputB.isOccupied = inputB.inputNode != null ? true : false;

            ParentGraph.wantsConnection = false;
            ParentGraph.connectionNode = null;
        }
        //adds sum of float nodes
        AddSum();

        DrawInputLines();
    }

    public override void DrawNodeProperties()
    {
        base.DrawNodeProperties();
        EditorGUILayout.FloatField("Sum: ", NodeSum);
    }

#endif

    void DrawInputLines()
    {
        if (inputA.isOccupied && inputA.inputNode != null)
            DrawLines(inputA, 1f);
        else
            inputA.isOccupied = false;

        if (inputB.isOccupied && inputB.inputNode != null)
            DrawLines(inputB, 2f);
        else
            inputB.isOccupied = false;
    }

    void DrawLines(NodeInput currentInput, float inputID)
    {
        Handles.BeginGUI();
        Handles.color = Color.white;
        Handles.DrawLine(new Vector3(currentInput.inputNode.NodeRect.x + currentInput.inputNode.NodeRect.width + 24f,
            currentInput.inputNode.NodeRect.y + (currentInput.inputNode.NodeRect.height * 0.5f), 0),
            new Vector3(NodeRect.x - 24, (NodeRect.y + (NodeRect.height * 0.33f) * inputID), 0f));
        Handles.EndGUI();
    }

    void AddSum()
    {
        FloatNode nodeA = (FloatNode)inputA.inputNode;
        FloatNode nodeB = (FloatNode)inputB.inputNode;

        if (nodeA != null && nodeB != null)
            NodeSum = nodeA.NodeValue + nodeB.NodeValue;
        else
            NodeSum = 0f;
    }
}