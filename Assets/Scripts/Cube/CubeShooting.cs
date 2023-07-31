using UnityEngine;

public class CubeShooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float reloadTime;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private AudioClip shotSound;

    private float _lastShotTime;

    [Header("Targeting")]
    [SerializeField] private ParticleSystem cursor;

    void Update()
    {
        cursor.transform.position = Targeting.GetTargetPosition();
    }

    #region Shooting

    public void TryShot()
    {
        if (Time.time - _lastShotTime > reloadTime)
        {
            Shot();
        }
    }

    private void Shot()
    {
        Vector3 direction = (cursor.transform.position - transform.position).normalized;
        direction.y = 0;

        Bullet shot = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        shot.Init(direction);

        Destroy(shot.gameObject, 3f);

        // Звук пострілу
        AudioManager.main.PlaySound(shotSound);

        _lastShotTime = Time.time;
    }

    #endregion

    #region Cursor

    private void Start()
    {
        Cursor.visible = false;
        cursor = Instantiate(cursor);
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
        Destroy(cursor.gameObject);
    }

    #endregion

    #region Upgrades

    public void SetDefaultReloadTime(float value)
    {
        reloadTime = value;
    }

    public void UpgradeReloadTime(float value)
    {
        reloadTime += value;
    }

    #endregion
}