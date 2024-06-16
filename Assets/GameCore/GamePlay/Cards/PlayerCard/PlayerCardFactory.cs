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

    public PlayerCardFactory(CardsPool cardsPool, IParentCardField parentCardField) : base(cardsPool, parentCardField)
    {
    }

    public override GameCardController CreateCard(Transform parent)
    {
        var type = typeof(PlayerCardController);

        GameCardView gameCardView = _cardsPool.CollectCard(type, parent);
        gameCardView.OnKill += () => _cardsPool.Release(type, gameCardView);

        return new PlayerCardController(HEALTH, _parentCardField, gameCardView);
    }
}
