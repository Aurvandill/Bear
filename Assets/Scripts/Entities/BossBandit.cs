using UnityEngine;
using System.Collections;

public class BossBandit : Melee {

    protected override void OnEntityDied()
    {
        Instantiate(_dieParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        _gameManager.onNotify(GameEvent.cr_BanditBoss_Killed);
        Destroy(gameObject);
    }
}
