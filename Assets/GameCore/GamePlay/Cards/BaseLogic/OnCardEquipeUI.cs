using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public class OnCardEquipeUI : MonoBehaviour
    {
        [SerializeField] private Image _equipeImage;
        [SerializeField] private TextMeshProUGUI _equipeDurability;

        public void ChangeDurability(string name) => _equipeDurability.SetText(name);

        public void Equipe(Sprite sprite)
        {
            _equipeImage.sprite = sprite;
            _equipeImage.enabled = true;
        }

        public void DeEquipe()
        {
            _equipeImage.enabled = false;
            _equipeImage.sprite = null;
        }
    }
}