using UnityEngine;

public class EnemyExplosive : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void Explode()
    {
        ParticleSystem explosion = Instantiate(_enemy.deathParticles, transform.position, Quaternion.identity);
        explosion.Play();

        ExplosionDamage();

        Destroy(explosion.gameObject, 2f);
        Destroy(gameObject);
    }

    private void ExplosionDamage()
    {
        float radius = transform.localScale.x * 2.5f;

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, _enemy.targetLayer);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(_enemy.explosionDamage);
            }
        }
    }
}