using UnityEngine;
using System.Collections;

public class FemaleBear : Entity {
	void OnTriggerEnter2D (Collider2D other) {
        if (other.GetComponent<Player>() != null)
        {
            _gameManager.onNotify(GameEvent.cr_BearGirl_TalkTo);
        }
	}
}
