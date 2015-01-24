using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestNode : System.Object
{
    private List<QuestCondition> _questConditions;
    private List<QuestNode> _questNodes;
    private bool _hasFinished;


    public QuestNode()
    {
        _questConditions = new List<QuestCondition>();
        _questNodes = new List<QuestNode>();
        _hasFinished = false;
    }


    public QuestNode AddChildren(QuestNode child)
    {
        _questNodes.Add(child);
        return this;
    }
    public QuestNode AddChildren(List<QuestNode> children)
    {
        _questNodes.AddRange(children);
        return this;
    }
    public QuestNode AddConditions(QuestCondition condition)
    {
        _questConditions.Add(condition);
        return this;
    }
    public QuestNode AddConditions(List<QuestCondition> conditions)
    {
        _questConditions.AddRange(conditions);
        return this;
    }
    public bool HasFinished(Dictionary<GameEvent, int> list)
    {
        if (!_hasFinished)
        {
            bool conditionsAreMet = false;
            foreach (var c in _questConditions)
            {
                if (!c.IsMet(list))
                {
                    conditionsAreMet = false;
                    break;
                }
                conditionsAreMet = true;
            }
            if (!conditionsAreMet) { return false; }

            foreach (var q in _questNodes)
            {
                if (!q.HasFinished(list)) { break; }
            }
            _hasFinished = true;
        }
        return _hasFinished;
    }
}
