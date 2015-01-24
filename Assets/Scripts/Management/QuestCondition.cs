using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestCondition : System.Object
{
    private GameEvent _event;
    private ComparisonOperator _operator;
    private int _value;


    public QuestCondition(GameEvent gameEvent, int targetValue)
    {
        _event = gameEvent;
        _operator = ComparisonOperator.Equals;
        _value = targetValue;
    }
    public QuestCondition(GameEvent gameEvent, int targetValue, ComparisonOperator comparisonOperator)
    {
        _event = gameEvent;
        _operator = comparisonOperator;
        _value = targetValue;
    }


    public bool IsMet(Dictionary<GameEvent, int> list)
    {
        bool isMet = false;
        switch (_operator)
        {
            case ComparisonOperator.Equals:
                isMet = (_value == list[_event]);
                break;
            case ComparisonOperator.GreaterOrEqualTo:
                isMet = (_value >= list[_event]);
                break;
            case ComparisonOperator.GreaterThan:
                isMet = (_value > list[_event]);
                break;
            case ComparisonOperator.LessOrEqualTo:
                isMet = (_value <= list[_event]);
                break;
            case ComparisonOperator.LessThan:
                isMet = (_value <= list[_event]);
                break;
            case ComparisonOperator.NotEqual:
                isMet = (_value <= list[_event]);
                break;
            default:
                isMet = false;
                break;
        }

        return isMet;
    }
}