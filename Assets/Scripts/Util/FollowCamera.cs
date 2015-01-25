using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject _target;

	void Update ()
    {
        if (_target != null)
        {
            transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
        }
	}
}
