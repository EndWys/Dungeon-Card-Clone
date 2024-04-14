using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Coin
{
    public class CoinCardPoolContainer : DefaultCardsPoolContainer
    {
        protected override GameObject _prefab => CardsDatabase.Instance.CoinCard;
    }
}