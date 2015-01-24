using UnityEngine;
using System.Collections;

public abstract class Creature : Entity
{
    private GameManager _gameManager;

    public override void Start()
    {
        base.Start();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected void NotifyGameEvent(GameEvent gameEvent)
    {
        if (_gameManager != null)
        {
            _gameManager.onNotify(gameEvent);
        }
        else
        {
            Debug.LogWarning("No GameManager component found");
        }
    }
}
