using UnityEngine;
using System.Collections;

public abstract class Entity : Creature
{
	[SerializeField]
	private float _initialHealth;
    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected Wearable _currentWearable;
    [SerializeField]
    protected Weapon _currentWeapon;

	private float _currentHealth;

	public bool IsAlive
	{
        get { return _currentHealth > 0; }
	}

    public virtual void ApplyDamage(float damage)
    {
        _currentHealth -= damage;

        OnHealthChanged(_currentHealth);
    }

    public void KnockBack(Vector3 force)
    {
        rigidbody2D.AddForce(force, ForceMode2D.Impulse);
    }

    protected virtual void OnHealthChanged(float health)
    {

    }
}
