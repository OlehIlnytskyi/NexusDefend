using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private ParticleSystem trailParticles;

    private Vector3 _direction;


    void Start()
    {
        // Ефект хвоста
        trailParticles = Instantiate(trailParticles, transform.position, Quaternion.identity);
        trailParticles.transform.parent = transform;

        // Ефект хвоста
        hitParticles = Instantiate(hitParticles, transform.position, Quaternion.identity);
        hitParticles.transform.parent = transform;
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
    }

    void Update()
    {
        Move();

        CheckHit();
    }

    private void Move()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void CheckHit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);

        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(damage);
                hitParticles.Play();

                Destroy(gameObject, 1.5f);
                Destroy(this);
            }
        }
    }

    #region Upgrades

    public void SetDefaultDamage(int value)
    {
        damage = value;
    }

    public void SetDefaultBulletSpeed(int value)
    {
        speed = value;
    }


    public void UpgradeDamage(int value)
    {
        damage += value;
    }

    public void UpgradeBulletSpeed(int value)
    {
        speed += value;
    }

    #endregion
}