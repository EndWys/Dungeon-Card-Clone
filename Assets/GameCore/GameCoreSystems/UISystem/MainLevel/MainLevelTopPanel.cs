using TMPro;
using UnityEngine;
using VContainer;

public class MainLevelTopPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCounter;

    private CoinsMatchManager _coinsMatchManager;

    [Inject]
    private void Construct(CoinsMatchManager coinsMatchManager)
    {
        _coinsMatchManager = coinsMatchManager;

        _coinsMatchManager.CurrencyChanged += OnCoinsChange;
    }

    private void OnCoinsChange(int value)
    {
        _coinsCounter.SetText(value.ToString());
    }
}
