using UnityEngine;
using System;
using System.Collections.Generic;

public class StoryLine : System.Object
{
    public string Name { get; private set; }

    private List<QuestNode> _questNodes;


    public StoryLine(string name)
    {
        Name = name;
        _questNodes = new List<QuestNode>();
    }


    public StoryLine AddChildren(QuestNode child)
    {
        _questNodes.Add(child);
        return this;
    }
    public StoryLine AddChildren(List<QuestNode> children)
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
