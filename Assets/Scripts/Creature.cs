using UnityEngine;
using System.Collections;

public abstract class Creature : Entity
{
	[SerializeField]
	private float _initialHealth;
    [SerializeField]
    protected float _moveSpeed;
	[SerializeField]
    protected Wearable _currentWearable;
    [SerializeField]
    protected Weapon _currentWeapon;

    private GameManager _gameManager;
	private float _currentHealth;

    public override void Start() {
		base.Start();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    }

    public void KnockBack(Vector3 force)
    {
        rigidbody2D.AddForce(force, ForceMode2D.Impulse);
    }

    protected virtual void OnHealthChanged(float health)
    {

    }
}
