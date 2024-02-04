using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

[Serializable]
public class NodeBase : ScriptableObject
{
    public string NodeName;
    public Rect NodeRect;
    public NodeGraph ParentGraph;
    public NodeType nodeType;
    public bool isSelected { get; set; } = false;

    protected GUISkin NodeSkin;
    protected string GUISkinName = "NodeDefault";

    [Serializable]
    public class NodeInput
    {
        public bool isOccupied = false;
        public NodeBase inputNode;
    }
    [Serializable]
    public class NodeOutput
    {
        public bool isOccupied = false;
    }

    public virtual void InitNode()
    {
        
    }

    public virtual void UpdateNode(Event e, Rect viewRect)
    {
        ProcessEvents(e, viewRect);
    }

    #if UNITY_EDITOR
    public virtual void UpdateNodeGUI(Event e, Rect viewRect, GUISkin viewSkin)
    {
        ProcessEvents(e, viewRect);

        GUISkinName = !isSelected ? "NodeDefault" : "NodeSelected";

        GUI.Box(NodeRect, NodeName, viewSkin.GetStyle(GUISkinName));

        EditorUtility.SetDirty(this);
    }

    public virtual void DrawNodeProperties()
    {

    }

    #endif

    void ProcessEvents(Event e, Rect viewRect)
    {
        if (!isSelected)
            return;

        DragNode(e, viewRect);
    }

    void DragNode(Event e, Rect viewRect)
    {
        if (viewRect.Contains(e.mousePosition))
        {
            if (e.type == EventType.MouseDrag)
            {
                NodeRect.x += e.delta.x;
                NodeRect.y += e.delta.y;
            }
        }
    }
}