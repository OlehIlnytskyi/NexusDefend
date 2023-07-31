using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform nexus;
    private Transform cube;

    private Vector3 _direction;

    private int _minDistance;

    private void Start()
    {
        _minDistance = (int)transform.position.y;

        _direction = transform.position.normalized;
    }

    void OnEnable()
    {
        nexus = Managers.main.levelsManager.GetNexus(Team.Blue).transform;
        cube = Managers.main.cubeManager.GetCubeTransform();
    }

    void LateUpdate()
    {
        if (nexus == null || cube == null) { return; }
        
        _neededPosition = nexus.position + GetNeededPosition((cube.position - nexus.position) / 2);

        if (transform.position == _neededPosition) { return; }

        MoveCamera();
    }

    private Vector3 GetNeededPosition(Vector3 pos)
    {
        float distance = Vector3.Distance(nexus.position, cube.position);

        if (distance < _minDistance)
        {
            return pos + _direction * _minDistance;
        }

        return pos + _direction * distance;
    }

    #region MoveCamera

    [SerializeField] private int cameraSpeed;
    private Vector3 _neededPosition;

    private void MoveCamera()
    {
        Vector3 direction = _neededPosition - transform.position;

        transform.Translate(direction * cameraSpeed * Time.deltaTime);

        // Костиль
        if (transform.position.y < 18){
            Vector3 newPosition = transform.position;
            newPosition.y = 18;
            transform.position = newPosition;
        }
    }

    #endregion
}