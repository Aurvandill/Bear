using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
	[SerializeField]
	private float _initialHealth;
    [SerializeField]
    protected float _baseDamage;
    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected Wearable _currentWearable;
    [SerializeField]
    protected GameObject _attackRange;

	private float _currentHealth;
    

	public bool IsAlive
	{
        get { return _currentHealth > 0; }
	}

    public abstract void Attack(Entity target);
    public virtual void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
