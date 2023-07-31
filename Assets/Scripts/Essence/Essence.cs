using UnityEngine;

public class Essence : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particlesPrefab;

    public int value;

    private void Start()
    {
        ParticleSystem particles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        particles.transform.parent = transform;

        transform.parent = Managers.main.levelsManager.GetNexus(Team.Blue).transform;

        Destroy(gameObject, 15f);
    }
}
