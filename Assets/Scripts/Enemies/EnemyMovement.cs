using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy       _enemy;

    private Rigidbody   _rb;
    private Vector3     _direction;
    private float       _distToGround;

    private float _checkTimer = 8f;
    private float _timer = 8f;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rb = GetComponent<Rigidbody>();

        _distToGround = GetComponent<Collider>().bounds.extents.y;

        randomRotation();
    }

    // Рух
    public void Move()
    {
        _timer += Time.deltaTime;
        
        if (!IsGrounded()) { return; }

        if (_timer >= _checkTimer){
            _direction = GetDirection();
            _timer = 0f;
        }

        SetVelocity();
    }

    // Це для тупості противників
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }

    private void SetVelocity(){
        _rb.velocity = _direction * _enemy.movementSpeed;
    }

    private Vector3 GetDirection(){
        Nexus blueNexus = Managers.main.levelsManager.GetNexus(Team.Blue);
        Vector3 nexusPosition = blueNexus.transform.position;
        
        Vector3 newDirection = (nexusPosition - transform.position).normalized;
        newDirection.y = 0f;

        return newDirection;
    }

    private void randomRotation(){
        transform.eulerAngles = new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
    }
}