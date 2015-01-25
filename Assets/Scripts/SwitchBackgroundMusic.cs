using UnityEngine;
using System.Collections;

public class SwitchBackgroundMusic : MonoBehaviour {

    [SerializeField]
    private int _soundIndex = 0;

    [SerializeField]
    private float _soundVolume = 1f;

    [SerializeField]
    private PlaySound _backgroundMusic;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (_backgroundMusic != null)
                _backgroundMusic.PlayFade(_soundIndex);
        }
    }
}
