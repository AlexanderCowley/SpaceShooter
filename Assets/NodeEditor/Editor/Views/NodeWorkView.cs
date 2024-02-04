using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NodeWorkView : NodeViewBase
{
    public int DeleteNodeID = 0;
    public NodeWorkView() : base("Work View"){}

    public override void ProcessEvents(Event e)
    {
        base.ProcessEvents(e);
        //Handle Context
        if (e.button == 1)
        {
            //have protected dictionary of context events in base class.
            //Declare them in the child class
            //move to base class
            if (e.type == EventType.MouseDown)
            {
                bool overNode = false;
                DeleteNodeID = 0;
                if(currentGraph != null)
                {
                    if (currentGraph.nodes.Count > 0)
                    {
                        for(int i = 0; i < currentGraph.nodes.Count; i++)
                        {
                            if(currentGraph.nodes[i].NodeRect.Contains(e.mousePosition))
                            {
                                DeleteNodeID = i;
                                overNode = true;
                                //break;
                            }
                        }
                    }
                }
                if (!overNode)
                    ProcessContextMenu(e, 0);
                else
                    ProcessContextMenu(e, 1);
            }
        }
    }

    public override void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph currentGraph)
    {
        base.UpdateView(editorRect, percentageRect, e, currentGraph);

        //Drawing Grid
        NodeUtility.DrawGrid(ViewRect, 50f, 0.15f, Color.white);

        //causing error
        GUILayout.BeginArea(ViewRect);
        currentGraph?.UpdateGraphGUI(e, ViewRect, viewSkin);
        GUILayout.EndArea();

        ProcessEvents(e);
    }

    void ProcessContextMenu(Event e, int contextID)
    {
        GenericMenu menu = new GenericMenu();

        if(contextID == 0)
        {
            menu.AddItem(new GUIContent("Create Graph"), false, ContextCallback, "0");
            menu.AddItem(new GUIContent("Load Graph"), false, ContextCallback, "1");
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Unload Graph"), false, ContextCallback, "2");
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Float Node"), false, ContextCallback, "3");
            menu.AddItem(new GUIContent("Add Node"), false, ContextCallback, "4");
        }

        if(contextID == 1)
        {
            if (currentGraph != null)
                menu.AddItem(new GUIContent("Delete Node"), false, ContextCallback, "5");
        }

        menu.ShowAsContext();
        e.Use();
    }
    //Dictionary string key
    void ContextCallback(object obj)
    {
        switch(obj.ToString())
        {
            case "0":
                NodePopUpWindow.InitPopUp();
                break;

            case "1":
                NodeUtility.LoadGraph();
                break;

            case "2":
                NodeUtility.UnloadGraph();
                break;

            case "3":
                NodeUtility.CreateNode(currentGraph, NodeType.Float, mousePosition);
                break;

            case "4":
                NodeUtility.CreateNode(currentGraph, NodeType.Add, mousePosition);
                break;

            case "5":
                NodeUtility.DeleteNode(DeleteNodeID, currentGraph);
                break;

            default:
                break;
        }
    }
}