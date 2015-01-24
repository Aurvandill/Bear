using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class QuestNode : System.Object
{
    [SerializeField]
    private List<QuestNode> _questNodes;
    [SerializeField]
    private List<QuestCondition> _questConditions;
    private bool _hasFinished;


    public QuestNode()
    {
        _questConditions = new List<QuestCondition>();
        _questNodes = new List<QuestNode>();
        _hasFinished = false;
    }


    public QuestNode AddChild(QuestNode child)
    {
        _questNodes.Add(child);
        return this;
    }
    public QuestNode AddChild(List<QuestNode> children)
    {
        _questNodes.AddRange(children);
        return this;
    }
    public QuestNode AddCondition(QuestCondition condition)
    {
        _questConditions.Add(condition);
        return this;
    }
    public QuestNode AddCondition(List<QuestCondition> conditions)
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
                if (!c.IsMet(list)) { break; }
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
