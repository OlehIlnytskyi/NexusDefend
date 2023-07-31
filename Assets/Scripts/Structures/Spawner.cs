using UnityEngine;

public class Spawner : Structure
{
    [Header("Spawner")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float creationTime;
    [SerializeField] private Essence essence;
    [SerializeField] private ParticleSystem spawnParticles;

    private float _timer;


    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= creationTime)
        {

            if (Random.value > 0.25f)
            {
                CreateEnemy();
            }

            _timer = 0f;
        }
    }

    private void CreateEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.transform.parent = transform;
    }

    public override void Die()
    {
        Instantiate(essence, transform.position + Vector3.up * 2, Quaternion.identity);

        base.Die();
        
        Destroy(spawnParticles.gameObject);
        Destroy(this);
    }
}
