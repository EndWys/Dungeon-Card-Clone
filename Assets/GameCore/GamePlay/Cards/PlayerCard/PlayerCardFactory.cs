using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using UnityEngine;

public class PlayerCardFactory : CardsFactoryBase
{
    //Temporary constanta
    private const int HEALTH = 10;

    public PlayerCardFactory(NewCardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
    {
    }

    protected override ICardsPoolContainer Pool => _cardsPool.PlayerCardPoolContainer;

    public override GameCardController CreateCard(Transform parent)
    {
        GameCardView gameCardView = Pool.CollectCard(parent);
        gameCardView.OnKill += () => Pool.ReleaseCard(gameCardView);

        return new PlayerCardController(HEALTH, _parentCardField, gameCardView);
    }
}
