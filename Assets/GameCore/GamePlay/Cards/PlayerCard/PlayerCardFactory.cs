using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using UnityEngine;

public class PlayerCardFactory : CardsFactoryBase
{
    //Temporary constanta
    private const int HEALTH = 10;

    public PlayerCardFactory(IParentCardField parentCardField) : base(parentCardField)
    {
    }

    protected override CardData _cardData => _database.PlayerCard;

    public override GameCardController CreateCard(Transform parent)
    {
        GameCardView gameCardView = _pool.CollectCard(parent);
        gameCardView.OnKill += () => _pool.ReleaseCard(gameCardView);

        return new PlayerCardController(_cardData, _parentCardField, gameCardView);
    }
}
