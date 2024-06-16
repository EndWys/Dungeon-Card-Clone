using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using UnityEngine;

public class CoinsCardFactory : CardsFactoryBase
{
    public CoinsCardFactory(CardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
    {
    }

    public override GameCardController CreateCard(Transform parent)
    {
        var type = typeof(CoinCardController);

        GameCardView gameCardView = _cardsPool.CollectCard(type, parent);
        gameCardView.OnKill += () => _cardsPool.Release(type, gameCardView);

        gameCardView.Init();

        return new CoinCardController(_parentCardField, gameCardView);
    }
}
