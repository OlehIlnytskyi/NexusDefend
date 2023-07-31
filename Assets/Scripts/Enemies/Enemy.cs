using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyExplosive))]
public class Enemy : DamageableObject
{
    [Header("Enemy")]
    public Essence essence;

    [Header("Movement")]
    public float movementSpeed;

    [Header("Explosion")]
    public ParticleSystem deathParticles;
    public LayerMask targetLayer;
    public int explosionDamage;


    public EnemyMovement enemyMovement { get; private set; }
    public EnemyExplosive enemyExplosive { get; private set; }

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyExplosive = GetComponent<EnemyExplosive>();
    }

    private void Update()
    {
        // Рухаємось
        enemyMovement.Move();
    }

    #region DamageableObject

    override public void GetDamage(int damage)
    {
        base.GetDamage(damage);
    }

    override public void Die()
    {
        base.Die();

        // Вносимо в результати що було вбито противника
        UIController.main.EnemyKilled();

        // Створюємо після нього ессенцію
        Instantiate(essence, transform.position, Quaternion.identity);

        // Взриваємось?
        enemyExplosive.Explode();
    }

    #endregion
}