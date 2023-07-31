using System.Collections;
using UnityEngine;

public class CubeDashing : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float dashPower = 100f;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashDelay = 0.3f;

    private Rigidbody _rb;
    private float _lastDashTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        particles = Instantiate(particles, transform.position, Quaternion.identity);
        particles.transform.parent = transform;
    }

    public void TryDash()
    {
        if (Time.time - _lastDashTime > dashDelay)
        {
            particles.Play();

            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            StartCoroutine(Dash(Time.time, direction));
        }
    }

    private IEnumerator Dash(float startTime, Vector3 direction)
    {
        if (Time.time - startTime > dashTime)
        {
            particles.Stop();
            _lastDashTime = Time.time;
            yield break;
        }

        _rb.velocity = direction * dashPower;

        yield return null;
        yield return Dash(startTime, direction);
    }

    #region Upgrades

    public void SetDefaultDashPower(int value)
    {
        dashPower = value;
    }

    public void UpgradeDashPower(int value)
    {
        dashPower += value;
    }

    #endregion
}