using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OpenRoof : MonoBehaviour {

    private SpriteRenderer _fadeingObject;

    void Start()
    {
        _fadeingObject = this.GetComponent<SpriteRenderer>();
    }


	void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _fadeingObject.color = new Color(_fadeingObject.color.r, _fadeingObject.color.g, _fadeingObject.color.b, 0f);
        }
    }

    void OnTriggerExit2D (Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _fadeingObject.color = new Color(_fadeingObject.color.r, _fadeingObject.color.g, _fadeingObject.color.b, 1f);
        }
    }
}
