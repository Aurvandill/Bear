using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private Dictionary<GameEvent, int> _gameStates;
    [SerializeField]
    private List<StoryLine> _storyLines;

    
    public void Start()
    {
        _gameStates = new Dictionary<GameEvent, int>();
        _storyLines = new List<StoryLine>();

        //Hibernation
        /*var hibernation = new StoryLine("Hibernation").AddChild(
            new QuestNode().AddCondition(
                new List<QuestCondition>()
                {
                    new QuestCondition(GameEvent.CaveEnter, 1),
                    new QuestCondition(GameEvent.WearableObtained, 0)
                }
            ));*/

    }


    public void onNotify(GameEvent gameEvent)
    {
        UpdateGameState(gameEvent, false);
    }
    public void onNotify(GameEvent gameEvent, bool undo)
    {
        UpdateGameState(gameEvent, undo);
    }


    private void UpdateGameState(GameEvent gameEvent, bool undo)
    {
        if (!undo && !_gameStates.ContainsKey(gameEvent))
            _gameStates[gameEvent] = 1;
        else if (undo && _gameStates.ContainsKey(gameEvent) && _gameStates[gameEvent] < 1)
            _gameStates.Remove(gameEvent);
        else
            _gameStates[gameEvent] += (undo ? -1 : 1);

        CheckStoryLines();
    }
    private void CheckStoryLines()
    {
        bool win = false;
        foreach (var s in _storyLines)
        {
            if (s.HasFinished(_gameStates))
            {
                win = true;
                break;
            }
        }

        if (win)
        {
            Debug.LogWarning("WINNING!");
        }
    }
}
