using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Entity
{
    private List<Entity> EnemiesInAttackRange = new List<Entity>();

    public void Update()
    {
        StartAttack();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public override void Attack(Entity target)
    {
        target.ApplyDamage(_baseDamage);
    }


    private void Move()
    {
        float moveH = Input.GetAxis("Horizontal") * _moveSpeed;
        float moveV = Input.GetAxis("Vertical") * _moveSpeed;

        rigidbody2D.velocity = new Vector2(moveH, moveV);
    }

    private void StartAttack()
    {
        if (Input.GetAxisRaw("Attack") == 1)
        {
            //add animation
        }
    }

    private void EndAttack()
    {
        foreach (var enemy in EnemiesInAttackRange)
        {
            _currentWeapon.AttackEntity(enemy);
        }
    }

    public void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_attackRange.name))
        {
            var enemy = args.Entity as Enemy;
            if (enemy != null)
            {
                EnemiesInAttackRange.Add(enemy);
            }
        }
    }

    public void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_attackRange.name))
        {
            var enemy = args.Entity as Enemy;
            if (enemy != null)
            {
                EnemiesInAttackRange.Remove(enemy);
            }
        }
    }
}
