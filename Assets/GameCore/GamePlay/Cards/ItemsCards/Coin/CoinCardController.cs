using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Coin
{
    public class CoinCardController : GameCardController, ICollectableCard
    {
        public CoinCardController(IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
        {

        }

        public void Collect()
        {
            //Add coin to player score
            //Then kill this card
            Debug.Log("Coin collected");
        }
    }
}