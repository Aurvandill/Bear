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
        var newPickup = Instantiate(gameObject, location, Quaternion.identity) as GameObject;
        newPickup.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void PickUp(Transform newOwner)
    {
        _spriteRenderer.enabled = false;
        transform.parent = transform;
    }
}
