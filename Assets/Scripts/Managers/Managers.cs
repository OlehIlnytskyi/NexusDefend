using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour, IManager
{
    #region Singletone

    public static Managers main { get; private set; }

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }

    #endregion

    public LevelsManager levelsManager { get; private set; }
    public CubeManager cubeManager { get; private set; }
    public CamerasManager camerasManager { get; private set; }

    private List<IManager> _managers;

    private void Start()
    {
        levelsManager = GetComponentInChildren<LevelsManager>();
        cubeManager = GetComponentInChildren<CubeManager>();
        camerasManager = GetComponentInChildren<CamerasManager>();

        _managers = new List<IManager>();
        
        _managers.Add(levelsManager);
        _managers.Add(cubeManager);
        _managers.Add(camerasManager);
    }

    public void StartGame()
    {
        // Скидуємо результати
        UIController.main.DropCounters();

        foreach (IManager manager in _managers)
        {
            manager.StartGame();
        }
    }

    public void EndGame()
    {   
        foreach (IManager manager in _managers)
        {
            manager.EndGame();
        }
    }

    public void Victory()
    {
        levelsManager.DeactivateSpawners();
        levelsManager.NextLevel();
    }

    public void Defeat()
    {
        levelsManager.DeactivateSpawners();
    }
}