using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;

[Serializable]
public class NodeViewBase
{
    public string ViewTitle;
    public Rect ViewRect;

    protected Vector2 mousePosition;

    protected GUISkin viewSkin;
    protected NodeGraph currentGraph;
    public NodeViewBase(string title)
    {
        this.ViewTitle = title;
        GetGUISkin();
    }

    public virtual void UpdateNode(Event e, Rect viewRect)
    {
        ProcessEvents(e);
    }

    public virtual void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph graph)
    {
        if (viewSkin == null)
        {
            GetGUISkin();
            return;
        }
        ViewRect = new Rect(editorRect.x * percentageRect.x, editorRect.y * percentageRect.y,
            editorRect.width * percentageRect.width,
            editorRect.height * percentageRect.height);

        this.currentGraph = graph;

        if (currentGraph != null)
        {
            ViewTitle = currentGraph?.GraphName;
        }
        else
            ViewTitle = "No Graph";

        currentGraph?.UpdateGraph(e, ViewRect, viewSkin);
    }

    public virtual void ProcessEvents(Event e)
    {
        if (ViewRect.Contains(e.mousePosition))
        {
            if (e.button == 0)
            {
                if (e.type == EventType.MouseDown)
                {
                    Debug.Log("Left Clicked in " + ViewTitle);
                }

                if (e.type == EventType.MouseDrag)
                {
                    Debug.Log("Left Click: Drag in " + ViewTitle);
                }

                if (e.type == EventType.MouseUp)
                {
                    Debug.Log("Left Click Up in " + ViewTitle);
                }
            }

            if (e.button == 1)
            {
                if (e.type == EventType.MouseDown)
                {
                    mousePosition = e.mousePosition;
                    Debug.Log("Right Clicked in " + ViewTitle);
                }
            }
        }
    }

    protected void GetGUISkin()
    {
        viewSkin = (GUISkin)Resources.Load("GUISkins/EditorSkins/NodeEditorSkin");
    }
}