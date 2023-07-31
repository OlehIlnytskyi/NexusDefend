using UnityEngine;

public class CubeManager : MonoBehaviour, IManager
{
    [SerializeField]
    private Transform cubePrefab;

    private Transform _currentCube;

    public void StartGame()
    {
        CreateCube();
    }

    public void EndGame()
    {
        DestroyCube();
    }

    private void CreateCube()
    {
        Vector3 startPosition = Managers.main.levelsManager.GetNexus(Team.Blue).transform.position + new Vector3(10f, 1f, 0f);
        _currentCube = Instantiate(cubePrefab, startPosition, Quaternion.identity);
    }

    private void DestroyCube()
    {
        Destroy(_currentCube.gameObject);
    }

    public Transform GetCubeTransform()
    {
        return _currentCube;
    }
}