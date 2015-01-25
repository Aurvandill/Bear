using UnityEngine;
using System.Collections;

public class Ranged : Enemy 
{
    private bool _isRunningAway;

    public void Update()
    {
        Attack();
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_currentWeapon.IsTargetInRange<Player>())
        {
            var direction = new Vector3();

            if (CurrentTarget != null)
            {
                direction = (CurrentTarget.gameObject.transform.position - transform.position).normalized;
                var directionY1D = (direction.y == 0) ? 0 : ((direction.y > 0) ? 1 : -1);

                if (directionY1D != 0)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + directionY1D * _moveSpeed);
                }
            }
            else if ((transform.position - ReturnPosition).magnitude > 0.1)
            {
                direction = (ReturnPosition - transform.position).normalized;
                transform.position = transform.position + direction * _moveSpeed;
            }

            var directionX1D = (direction.x == 0) ? 0 : ((direction.x > 0) ? 1 : -1);
            if (directionX1D != 0)
            {
                transform.localScale = new Vector3(directionX1D, transform.localScale.y, transform.localScale.z);
            }
        }

        if (_isRunningAway)
        {
            var fleeFromPosition = CurrentTarget.gameObject.transform.position;

            var direction = (transform.position - fleeFromPosition).normalized;
            transform.position = transform.position + direction * _moveSpeed;
        }
    }

    private void Attack()
    {
        if (_currentWeapon.IsTargetInRange<Player>() && !_isRunningAway)
        {
            _currentWeapon.Attack();
        }
    }

    public override void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        var player = args.Entity as Player;
        if (player == null)
        {
            return;
        }

        if (args.SenderId.Equals(_aggressionRange.name))
        {
            CurrentTarget = player;
        }

        if (args.SenderId.Equals(_disengageRange.name))
        {
            _isRunningAway = true;
        }
    }

    public override void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        var player = args.Entity as Player;
        if (player == null)
        {
            return;
        }

        if (args.SenderId.Equals(_aggressionRange.name))
        {
            CurrentTarget = null;
        }

        if (args.SenderId.Equals(_disengageRange.name))
        {
            _isRunningAway = false;
        }
    }
}
