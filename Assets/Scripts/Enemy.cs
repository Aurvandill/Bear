using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
	[SerializeField]
	private float _aggressionRange;
    [SerializeField]
    private float _movementRange;

    private Entity _currentTarget;

    private void Update()
    {
        
    }

    public void Attack(Entity target)
    {
        target.ApplyDamage();
    }

    private bool IsEntityInAggressionRange(Entity entity)
    {
        var positionDelta = Mathf.Abs(entity.transform.position.x - transform.position.x);

        return positionDelta <= _aggressionRange;
    }
}
