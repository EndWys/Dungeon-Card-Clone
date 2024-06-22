using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.GamePlay.MainHeroOptions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class PotionCardController : GameCardController, ICollectableCard
    {
        private int _healAmount;

        public PotionCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
        {
            _healAmount = cardData.CardValueNumber;

            _gameCardView.OnCardUI.SetCardName(cardData.CardName);
            _gameCardView.OnCardUI.SetCardValue(_healAmount.ToString());

        }

        public void Collect()
        {
            Action<PlayerCardController> consume = (player) =>
            {
                player.Heal(_healAmount);
            };

            MainHeroHolder.Instance.ConsumeItem(consume);
            Debug.Log("Coin collected");
        }
    }
}