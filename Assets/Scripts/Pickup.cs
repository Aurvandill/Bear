using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

	public virtual void Start() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void Drop(Vector3 location)
    {
        _spriteRenderer.enabled = true;
        _spriteRenderer.transform.position = location;
        _spriteRenderer.transform.parent = null;
    }

    public void PickUp(Transform newOwner)
    {
        _spriteRenderer.enabled = false;
        _spriteRenderer.transform.parent = transform;
    }
}
