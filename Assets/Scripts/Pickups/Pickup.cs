using UnityEngine;
using System.Collections;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject _pickupKeyHint;
    private SpriteRenderer _spriteRenderer;

	public virtual void Start() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void Drop(Vector3 location)
    {
        var newPickup = Instantiate(gameObject, location, Quaternion.identity) as GameObject;
        newPickup.GetComponent<SpriteRenderer>().enabled = true;

        var keyHint = Instantiate(_pickupKeyHint) as GameObject;
        keyHint.transform.parent = newPickup.transform;
        keyHint.transform.localPosition = new Vector3(1.5f, 1.5f, 0);

        var keyHintCollider = keyHint.GetComponent<BoxCollider2D>();
        keyHintCollider.center = new Vector2(-1.5f, -1.5f);
        keyHintCollider.size = new Vector2(1.5f, 1.5f);
    }

    public void PickUp(Transform newOwner)
    {
        _spriteRenderer.enabled = false;
        transform.parent = transform;
    }
}
