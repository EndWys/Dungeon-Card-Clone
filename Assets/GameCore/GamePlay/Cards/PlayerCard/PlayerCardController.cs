using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.PlayerCard
{
    public class PlayerCardController : GameCardController, IHealableCard
    {
        private int _health = 0;
        private int _maxHealth = 0;
        private string _healthString => _health.ToString();
        public int Health => _health;

        public PlayerCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
        {
            _health = cardData.CardValueNumber;
            _maxHealth = _health;

            _gameCardView.OnCardUI.SetCardName(cardData.CardName);
            _gameCardView.OnCardUI.SetCardValue(_healthString);

            MainHeroHolder.Instance.Init(this);
        }

        public void TakeDamage(int damage)
        {
            if (_health <= damage)
                _health = 0;
            else
                _health -= damage;

            _gameCardView.OnCardUI.SetCardValue(_healthString);
        }

        public void Heal(int amount)
        {
            int newHealth = _health + amount;

            if (newHealth > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health = newHealth;
            }

            _gameCardView.OnCardUI.SetCardValue(_healthString);
        }

        public async UniTask StepDone()
        {
            await _parentCardField.Step();
        }
    }
}