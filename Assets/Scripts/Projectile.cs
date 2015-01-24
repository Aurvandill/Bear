using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected GameObject _impactRange;

    public float Damage { get; set; }

    public void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_impactRange.name))
        {
            var entity = args.Entity as Enemy;
            if (entity != null)
            {
                entity.ApplyDamage(Damage);
            }
            Object.Destroy(this.gameObject);
        }
    }
}
