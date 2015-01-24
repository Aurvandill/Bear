using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class StoryLine : System.Object
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private List<QuestNode> _questNodes;


    public StoryLine(string name)
    {
        _name = name;
        _questNodes = new List<QuestNode>();
    }


    public StoryLine AddChild(QuestNode child)
    {
        _questNodes.Add(child);
        return this;
    }
    public StoryLine AddChild(List<QuestNode> children)
    {
        _questNodes.AddRange(children);
        return this;
    }
    public bool HasFinished(Dictionary<GameEvent, int> list)
    {
        foreach (var c in _questNodes)
        {
            if (!c.HasFinished(list)) { return false; }
        }
        return true;
    }
}
