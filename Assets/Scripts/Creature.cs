using UnityEngine;
using System.Collections;

public abstract class Creature : Entity
{
	[SerializeField]
	private float _initialHealth;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected GameObject _dieParticle;

    [SerializeField]
    protected Wearable _currentWearable;
    [SerializeField]
    protected Weapon _currentWeapon;

	private float _currentHealth;

    public override void Start() {
		base.Start();
        _currentHealth = _initialHealth;
	}
		
	public bool IsAlive
	{
		get { return _currentHealth > 0; }
	}

    public virtual void ApplyDamage(float damage)
    {
        _currentHealth -= damage;

        OnHealthChanged(_currentHealth);

        if (!IsAlive)
        {
            OnEntityDied();
        }
    }

    public void KnockBack(Vector3 force)
    {
        rigidbody2D.AddForce(force, ForceMode2D.Impulse);
    }

    protected virtual void OnHealthChanged(float health)
    {

    }

    protected virtual void OnEntityDied()
    {
        Instantiate(_dieParticle, transform.position, Quaternion.EulerRotation(-90, 0, 0));
        Destroy(gameObject);
    }
}
