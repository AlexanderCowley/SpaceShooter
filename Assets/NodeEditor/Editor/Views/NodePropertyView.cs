using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class NodePropertyView : NodeViewBase
{
    public NodePropertyView():base("Property View"){}

    public override void ProcessEvents(Event e)
    {
        base.ProcessEvents(e);
    }

    public override void UpdateView(Rect editorRect, Rect percentageRect, Event e, NodeGraph currentGraph)
    {
        base.UpdateView(editorRect, percentageRect, e, currentGraph);
        GUI.Box(ViewRect, ViewTitle, viewSkin.GetStyle("ViewBG"));
        //causing error
        GUILayout.BeginArea(ViewRect);
        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Space(30);
        if (currentGraph != null)
        {
            if (currentGraph.showProperties)
                currentGraph.selectedNode.DrawNodeProperties();
            else
                EditorGUILayout.LabelField("None");
        }
        GUILayout.Space(30);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

        ProcessEvents(e);
    }
}