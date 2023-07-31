using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UpgradeSlot : MonoBehaviour
{
    [Header("Upgrade Methods")]
    [SerializeField] private UnityEvent defaultsMethod;
    [SerializeField] private UnityEvent upgradeMethod;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI currentLevelDataText;
    [SerializeField] private TextMeshProUGUI nextLevelDataText;

    [Header("Upgrade Data")]
    [SerializeField] private int pricePerGrade;

    [SerializeField] private float startValue;
    [SerializeField] private float valuePerGrade;

    public int nextLevelPrice { get; private set; }

    private int _maxLevel;
    private int _currentLevel;
    private float _currentValue;

    private void Start()
    {
        defaultsMethod.Invoke();

        _maxLevel = 3;
        _currentLevel = 1;
        _currentValue = startValue;
        nextLevelPrice = pricePerGrade;

        UpdateData();
    }

    public void UpdateData()
    {
        // UI Text
        lvlText.text = "Lvl. " + _currentLevel.ToString();
        priceText.text = nextLevelPrice.ToString() + " es";

        currentLevelDataText.text = "Lvl. " + _currentLevel.ToString() + " - " + _currentValue.ToString();

        nextLevelDataText.text = "Lvl. " + (_currentLevel + 1).ToString() + " - " + (_currentValue + valuePerGrade).ToString();

        if ((_currentLevel - 1) == _maxLevel)
        {
            priceText.text = "Max Lvl.";
            nextLevelDataText.text = "Max Lvl.";
        }
    }

    public void TryUpgrade()
    {
        if ((_currentLevel - 1) == _maxLevel) { return; }

        if (EssenceManager.main.TryRemoveEssence(nextLevelPrice) == false) { return; }

        upgradeMethod.Invoke();

        _currentLevel++;
        _currentValue = startValue + (valuePerGrade * (_currentLevel - 1));
        nextLevelPrice = pricePerGrade * _currentLevel;

        UpdateData();
    }

    public void NextGrade()
    {
        _maxLevel += 3;
    }
}