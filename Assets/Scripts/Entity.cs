using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
	[SerializeField]
	private int _initialHealth;
    [SerializeField]
    private Wearable _currentWearable;
    [SerializeField]
    private int _baseDamage;

	private int _currentHealth;
    

	public bool IsAlive
	{
        get { return _currentHealth > 0; }
	}

    public abstract void Attack()
    {

    }
}
