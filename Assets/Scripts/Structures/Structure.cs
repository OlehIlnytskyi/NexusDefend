using UnityEngine;

public class Structure : DamageableObject
{
    [Header("Structure")]
    [SerializeField] private ParticleSystem hitParticles;

    override public void GetDamage(int damage)
    {
        base.GetDamage(damage);

        Vector3 particlesOffset = GetRandomPositionInCollider();
        ParticleSystem hit = Instantiate(hitParticles, transform.position + particlesOffset, Quaternion.identity);
        hit.Play();

        Destroy(hit.gameObject, 1f);
    }

    override public void Die()
    {
        // Знищуємо загальний коллайдер
        Destroy(GetComponent<Collider>());

        // Вмикаємо rigidbody для дітей
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }

    private Vector3 GetRandomPositionInCollider(){
        Vector3 size = GetComponent<Collider>().bounds.size;

        float x = Random.Range(0f, size.x / 1.5f);
        float y = Random.Range(0f, size.y / 1.5f);
        float z = Random.Range(0f, size.z / 1.5f);

        return new Vector3(x, y, z);
    }
}
