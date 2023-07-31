using UnityEngine;

public class LevelsManager : MonoBehaviour, IManager
{
    [SerializeField] private Level[] levels;

    public int currentLevelIndex { get; private set; }

    private Level _currentLevel;

    public void StartGame()
    {
        CreateLevel();
    }

    public void EndGame()
    {
        DestroyLevel();
    }

    public void NextLevel()
    {
        currentLevelIndex++;
    }


    private void CreateLevel()
    {
        _currentLevel = Instantiate(levels[currentLevelIndex]);
    }

    private void DestroyLevel()
    {
        Destroy(_currentLevel.gameObject);
    }

    public Nexus GetNexus(Team team)
    {
        Nexus nexus;

        if (team == Team.Blue)
        {
            nexus = _currentLevel.blueNexus;
        }
        else
        {
            nexus = _currentLevel.redNexus;
        }

        return nexus;
    }

    public void DeactivateSpawners()
    {
        Spawner[] spawners = _currentLevel.GetComponentsInChildren<Spawner>();

        foreach (Spawner spawner in spawners)
        {
            spawner.enabled = false;
        }
    }
}