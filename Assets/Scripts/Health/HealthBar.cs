using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform _parent;

    private float _startScaleX;
    private float _heightOffset;

    void Start()
    {
        _parent = transform.parent;

        // Коллайдер об'єкта
        Vector3 colliderSize = _parent.GetComponent<Collider>().bounds.size;

        // Висота шкали здоров'я
        _heightOffset = colliderSize.y * 1.5f;

        // Довжина шкали здоров'я
        _startScaleX = transform.localScale.x * colliderSize.x;

        SetScale(_startScaleX);

    }

    void Update()
    {
        // Тримаємо бар над "головою"
        transform.position = _parent.position + new Vector3(0f, _heightOffset, 0f);

        // Забороняємо крутитись
        Vector3 eulers = transform.eulerAngles;
        eulers.x = 0;
        eulers.z = 0;
        transform.eulerAngles = eulers;
    }

    // Викликається при зміні здоров'я
    public void UpdateHealthBar(float health, float maxHealth)
    {
        // Вираховуємо потрібну довжину
        float xScale = _startScaleX * (health / maxHealth);

        // Встановлюємо потрібну довжину
        SetScale(xScale);
    }

    // Встановлення потрібної довжини шкали здоров'я
    private void SetScale(float xScale)
    {

        Vector3 newScale = transform.localScale;
        newScale.x = xScale;
        transform.localScale = newScale;
    }
}
