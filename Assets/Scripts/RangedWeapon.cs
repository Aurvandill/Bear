using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private float _projectileSpeed;

    public override void Attack()
    {
        if (CanAttack())
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, new Quaternion()) as GameObject;
            projectile.GetComponent<Projectile>().Damage = _baseDamage;
            projectile.rigidbody2D.AddForce(Vector2.right * transform.parent.localScale.x * _projectileSpeed, ForceMode2D.Force);
        }
    }
}
