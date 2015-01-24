using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    protected GameManager _gameManager;

    public virtual void Start()
    {
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
