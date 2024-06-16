using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.PlayerCard
{
    public class PlayerCardController : GameCardController, IHealableCard
    {
        private int _health = 0;
        private string _healthString => _health.ToString();
        public int Health => _health;

        public PlayerCardController(int health, IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
        {
            _health = health;
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

        public void Heal()
        {
            //Heal logic
        }

        public void StepDone()
        {
            _parentCardField.Step();
        }
    }
}