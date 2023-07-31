using UnityEngine;

public class EssenceCollector : MonoBehaviour
{
    [SerializeField] private int radius;
    [SerializeField] private float essenceSpeed;
    [SerializeField] private LayerMask essenceLayer;

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, essenceLayer);

        foreach (Collider collider in colliders)
        {
            Vector3 direction = (transform.position - collider.transform.position).normalized;
            collider.transform.Translate(Time.deltaTime * essenceSpeed * direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Essence essence = other.GetComponent<Essence>();

        if (essence != null)
        {
            EssenceManager.main.AddEssence(essence.value);

            UIController.main.EssenceCollected(essence.value);

            Destroy(essence.gameObject);
        }
    }
}