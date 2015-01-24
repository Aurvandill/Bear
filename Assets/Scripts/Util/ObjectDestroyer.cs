using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    public void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

	void Update () 
    {
        if (_particleSystem.isStopped)
        {
            Destroy(gameObject);
        }
	}
}
