using TMPro;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public class OnCardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cardName;
        [SerializeField] private TextMeshProUGUI _cardValue;

        public void SetCardName(string name) => _cardName.text = name;

        public void SetCardValue(string value) => _cardValue.text = value;

    }
}