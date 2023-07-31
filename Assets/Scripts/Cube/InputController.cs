using UnityEngine;

public class InputController : MonoBehaviour
{
    private CubeShooting _cubeShooting;
    private CubeDashing _cubeDashing;
    private CubeMovement _cubeMovement;

    void Start()
    {
        _cubeShooting = GetComponent<CubeShooting>();
        _cubeDashing = GetComponent<CubeDashing>();
        _cubeMovement = GetComponent<CubeMovement>();
    }

    void Update()
    {
        // Shooting
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _cubeShooting.TryShot();
        }

        // Dashing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cubeDashing.TryDash();
        }

        // Movement
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        if (xAxis != 0 || zAxis != 0)
        {
            _cubeMovement.Move(xAxis, zAxis);
        }
    }
}
