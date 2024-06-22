using TMPro;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public class OnCardAdditionalWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cardName;

        public void ChangeValue(string name) => _cardName.text = name;
    }
}