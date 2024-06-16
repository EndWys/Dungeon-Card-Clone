using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using UnityEngine;

public class CoinsCardFactory : CardsFactoryBase
{
    public CoinsCardFactory(NewCardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
    {
    }

    protected override ICardsPoolContainer Pool => _cardsPool.CoinCardPoolContainer;

    public override GameCardController CreateCard(Transform parent)
    {
        GameCardView gameCardView = Pool.CollectCard(parent);
        gameCardView.OnKill += () => Pool.ReleaseCard(gameCardView);

        return new CoinCardController(_parentCardField, gameCardView);
    }
}
