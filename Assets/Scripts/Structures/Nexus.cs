using UnityEngine;

public class Nexus : Structure
{
    [SerializeField] private Team team;

    private static bool isPlaying;

    private void Start()
    {
        isPlaying = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (team == Team.Red) { return; }

        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.enemyExplosive.Explode();
        }
    }

    public override void Die()
    {
        base.Die();

        // Вимикаємо анімації
        GetComponent<Animation>().enabled = false;

        if (!isPlaying) { return; }

        // Перевірка фіналу
        if (team == Team.Red && Managers.main.levelsManager.currentLevelIndex == 4)
        {
            isPlaying = false;
            UIController.main.Final();
            return;
        }

        isPlaying = false;

        if (team == Team.Red) { UIController.main.RedNexusDestroyed(); }
        if (team == Team.Blue) { UIController.main.BlueNexusDestroyed(); }
    }
}

public enum Team
{
    Blue,
    Red
}