using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Currencies;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Coin
{
    public class CoinCardController : GameCardController, ICollectableCard
    {
        private int _value;

        public CoinCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) 
            : base(cardData, parentCardField, gameCardView)
        {
            _value = cardData.CardValueNumber;

            _gameCardView.OnCardUI.SetCardName(cardData.CardName);
            _gameCardView.OnCardUI.SetCardValue(cardData.CardValueNumber.ToString());

        }
        
        public void Collect()
        {
            //Add coin to player score
            //Then kill this card
            Debug.Log("Coin collected");
            CoinsGlobalManager.Instance.AddCurrency(_value);
            CoinsMatchManager.Instance.AddCurrency(_value);
        }
    }
}