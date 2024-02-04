using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections.Generic;

[Serializable]
public class NodeGraph : ScriptableObject
{
    public string GraphName = "New Graph";
    public List<NodeBase> nodes;

    public NodeBase selectedNode;

    public bool wantsConnection = false;
    public NodeBase connectionNode;

    public bool showProperties;
    void OnEnable()
    {
        if (nodes == null)
            nodes = new List<NodeBase>();
    }

    public void InitGraph()
    {
        if (nodes.Count <= 0)
            return;

        for(int i = 0; i < nodes.Count; i++)
        {
            nodes[i].InitNode();
        }
    }

    public void UpdateGraph(Event e, Rect viewRect, GUISkin viewSkin)
    {
        if (nodes.Count <= 0)
            return;
    }


    #if UNITY_EDITOR
    public void UpdateGraphGUI(Event e, Rect viewRect, GUISkin viewSkin)
    {
        //updates the nodes while in the editor
        if (nodes.Count <= 0)
            return;

        ProcessEvents(e, viewRect);

        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].UpdateNodeGUI(e, viewRect, viewSkin);
        }
        //Connection Nodes Logic
        if (wantsConnection)
        {
            if(connectionNode != null)
            {
                DrawConnectionToMouse(e.mousePosition);
            }
        }

        if (e.type == EventType.Layout)
        {
            if (selectedNode != null)
            {
                showProperties = true;
            }
        }

        EditorUtility.SetDirty(this);
    }
    #endif
    public void ProcessEvents(Event e, Rect viewRect)
    {
        if (nodes.Count <= 0)
            return;

        if (viewRect.Contains(e.mousePosition))
        {
            //Managing Slection
            if(e.button == 0)
            {
                if(e.type == EventType.MouseDown)
                {
                    DeselectAllNodes();
                    //shows properties move to views or nodes?
                    showProperties = false;
                    bool overNode = false;
                    selectedNode = null;
                    //Checking if any of the nodes has the mouse hovering over it
                    for(int i = 0; i < nodes.Count; i++)
                    {
                        if(nodes[i].NodeRect.Contains(e.mousePosition))
                        {
                            overNode = true;
                            selectedNode = nodes[i];
                            selectedNode.isSelected = true;
                        }
                    }
                    if (!overNode)
                    {
                        DeselectAllNodes();
                    }
                    //makes sure the appropriate nodes get assigned as opposed to setting the wantsconnection flag to false
                    //and connection node to null
                    wantsConnection = wantsConnection ? false : wantsConnection;
                        
                }
            }
        }
    }

    void DeselectAllNodes()
    {
        for(int i = 0; i < nodes.Count; i++)
            nodes[i].isSelected = false;
    }

    void DrawConnectionToMouse(Vector2 mousePosition)
    {
        Handles.BeginGUI();
        Handles.color = Color.white;
        Handles.DrawLine(new Vector3(connectionNode.NodeRect.x + connectionNode.NodeRect.width + 24f, 
            connectionNode.NodeRect.y + connectionNode.NodeRect.height * 0.5f, 0), 
            new Vector3(mousePosition.x, mousePosition.y, 0));
        Handles.EndGUI();
    }
}