using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using UnityEngine;

public class CoinsCardFactory : CardsFactoryBase
{
    public CoinsCardFactory(IParentCardField parentCardField) : base(parentCardField)
    {
    }

    protected override CardData _cardData => _database.CoinCard;

    public override GameCardController CreateCard(Transform parent)
    {
        GameCardView gameCardView = _pool.CollectCard(parent);
        gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

        return new CoinCardController(_cardData, _parentCardField, gameCardView);
    }
}
