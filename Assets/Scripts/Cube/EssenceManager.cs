using UnityEngine;

public class EssenceManager : MonoBehaviour
{
    #region Singletone

    public static EssenceManager main { get; private set; }

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

    [SerializeField] private UIController uIController;

    public int essence { get; private set; }

    public void AddEssence(int value)
    {
        essence += value;

        uIController.UpdateEssenceInShop(essence);
    }

    public bool TryRemoveEssence(int value)
    {
        if (essence >= value)
        {
            essence -= value;
            uIController.UpdateEssenceInShop(essence);
            return true;
        }

        return false;
    }
}