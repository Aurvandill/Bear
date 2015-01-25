using UnityEngine;
using System.Collections;

public class Pickup : Entity
{
    public GameEvent PickupEvent;

    [SerializeField]
    private GameObject _pickupKeyHint;
    private SpriteRenderer _spriteRenderer;

    public bool IsDropped { get; set; }

    public void Start()
    {
        base.Start();

        var keyHint = Instantiate(_pickupKeyHint) as GameObject;
        keyHint.transform.parent = transform;
        keyHint.transform.localPosition = new Vector3(1.5f, 1.5f, 0);

        var keyHintCollider = keyHint.GetComponent<BoxCollider2D>();
        keyHintCollider.center = new Vector2(-1.5f, -1.5f);
        keyHintCollider.size = new Vector2(1.5f, 1.5f);
    }

    public void PickUp()
    {
        _gameManager.onNotify(PickupEvent);
        Destroy(gameObject);
    }
}
