using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI essenceText;

    public void SetEssenceUI(int value)
    {
        essenceText.text = value.ToString() + " es";
    }
}