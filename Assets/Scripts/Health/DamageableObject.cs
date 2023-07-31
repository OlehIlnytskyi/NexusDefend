using UnityEngine;

public abstract class DamageableObject : MonoBehaviour, IDamageable, IDieable, IUpgradeable
{
    [SerializeField] public int maxHealth;
    private int _currentHealth;

    [SerializeField] private HealthBar healthBarPrefab;
    private HealthBar _healthBar;

    [SerializeField]
    private bool _hasHealthBar;

    void Awake()
    {
        _currentHealth = maxHealth;

        if (_hasHealthBar)
        {
            _healthBar = Instantiate(healthBarPrefab);
            _healthBar.transform.parent = transform;
        }
    }

    #region IDamageable

    public virtual void GetDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.UpdateHealthBar(_currentHealth, maxHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }

    }

    #endregion

    #region IDieable

    public virtual void Die()
    {
        Destroy(this);
    }

    #endregion

    #region IUpgradeable

    public void SetDefaultValue(float value)
    {
        maxHealth = (int)value;
    }

    public void UpgradeValue(float value)
    {
        maxHealth += (int)value;
    }

    #endregion
}