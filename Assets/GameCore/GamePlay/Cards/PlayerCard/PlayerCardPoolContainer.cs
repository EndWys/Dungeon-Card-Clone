using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;

public class PlayerCardPoolContainer : DefaultCardsPoolContainer
{
    protected override GameObject _prefab => CardsDatabase.Instance.PlayerCard;
}
