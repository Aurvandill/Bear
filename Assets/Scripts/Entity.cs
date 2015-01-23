using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	[SerializeField]
	private int _initialHealth;
	private int _currentHealth;

	public bool IsAlive
	{
        get { return _currentHealth > 0; }
	}
}
