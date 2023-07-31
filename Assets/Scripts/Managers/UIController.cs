using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Singletone

    public static UIController main { get; private set; }

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }

    #endregion

    private Animation UIAminationComponent;

    [Header("AfterGame UI")]
    [SerializeField] private TextMeshProUGUI enemyKilled;
    [SerializeField] private TextMeshProUGUI essenceCollected;

    [Header("InGame UI")]
    [SerializeField] private TextMeshProUGUI essencePerRound;

    [Header("Shop")]
    [SerializeField] private TextMeshProUGUI shopEssence;

    private void Start()
    {
        UIAminationComponent = GetComponent<Animation>();
    }

    #region SceneCalls

    public void StartButton()
    {
        UIAminationComponent.Play("StartGame");
    }

    public void EnterShop()
    {
        UIAminationComponent.Play("EnterShop");
    }

    public void ExitShop()
    {
        UIAminationComponent.Play("ExitShop");
    }

    public void Next_RetryButton()
    {
        UIAminationComponent.Play("Next_Retry");
    }

    public void MenuButton()
    {
        // Вмикаємо музику головного меню
        AudioManager.main.PlayMainMenuMusic();
        
        UIAminationComponent.Play("EndGame");
    }

    public void RedNexusDestroyed()
    {
        UIAminationComponent.Play("Victory");
    }

    public void BlueNexusDestroyed()
    {
        UIAminationComponent.Play("Defeat");
    }

    #endregion

    #region AnimationCalls

    public void StartGame()
    {
        Managers.main.StartGame();
    }

    public void EndGame()
    {
        Managers.main.EndGame();
    }

    public void Victory()
    {
        Managers.main.Victory();
    }

    public void Defeat()
    {
        Managers.main.Defeat();
    }

    #endregion

    #region InGameUI

    private int _enemyKilled;
    private int _essenceCollected;

    public void EnemyKilled()
    {
        _enemyKilled++;
        UpdateResults();
    }

    public void EssenceCollected(int value)
    {
        _essenceCollected += value;
        UpdateResults();
    }

    public void DropCounters()
    {
        _enemyKilled = 0;
        _essenceCollected = 0;

        UpdateResults();
    }

    public void UpdateResults()
    {
        // InGame
        essencePerRound.text = _essenceCollected.ToString() + " es";

        // AfterGame
        enemyKilled.text = "Enemies killed - " + _enemyKilled.ToString();
        essenceCollected.text = "Essence collected - " + _essenceCollected.ToString();
    }

    #endregion

    #region Shop

    [SerializeField] private UpgradeSlot[] upgradeSlots;

    public void NextGradeInShop()
    {
        foreach (UpgradeSlot upgradeSlot in upgradeSlots)
        {
            upgradeSlot.NextGrade();
            upgradeSlot.UpdateData();
        }
    }

    public void UpdateEssenceInShop(int value)
    {
        shopEssence.text = value.ToString() + " es";
    }

    #endregion

    #region Final

    public void Final()
    {
        UIAminationComponent.Play("Final");
    }

    #endregion
}