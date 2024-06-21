using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Potion;
using Assets.GameCore.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameCore.GamePlay.Cards.BaseLogic;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.WeaponsCard.Sword
{
    public class SwordCardFactory : CardsFactoryBase
    {
        public SwordCardFactory(IParentCardField parentCardField) : base(parentCardField)
        {
        }

        protected override CardData _cardData => _database.SwordCard;

        public override GameCardController CreateCard(Transform parent)
        {
            GameCardView gameCardView = _pool.CollectCard(parent);
            gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

            return new SwordCardController(_cardData, _parentCardField, gameCardView);
        }
    }
}