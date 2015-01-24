using UnityEngine;
using System.Collections;

public class Player : Entity
{
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
}
