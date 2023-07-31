using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(float x, float z)
    {
        _rb.velocity = new Vector3(x, 0f, z) * movementSpeed + new Vector3(0f, -4f, 0f);
    }

    #region Upgrades

    public void SetDefaultMoveSpeed(float value)
    {
        movementSpeed = value;
    }

    public void UpgradeMoveSpeed(float value)
    {
        movementSpeed += value;
    }

    #endregion
}