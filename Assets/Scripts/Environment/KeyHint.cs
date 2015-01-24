using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class KeyHint : MonoBehaviour {

    [SerializeField]
    private string _key = "W";

    [SerializeField]
    private string _hint = "Something happens if you press this key!";

    [SerializeField]
    private TextMesh _keyMesh;

    [SerializeField]
    private TextMesh _hintMesh;

    private List<MeshRenderer> _renderers = new List<MeshRenderer>();
    private SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {

        _renderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            MeshRenderer mr = transform.GetChild(i).GetComponent<MeshRenderer>();

            if (mr != null)
                _renderers.Add(mr);
        }

        SetVisibility(false);
	}

    public void Redraw()
    {
        _keyMesh.text = _key;
        _hintMesh.text = _hint;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SetVisibility(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SetVisibility(false);
        }
    }

    void SetVisibility(bool visible)
    {
        _renderer.enabled = visible;

        for (int i = 0; i < _renderers.Count; i++)
        {
            _renderers[i].enabled = visible;
        }
    }
}
