using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using UnityEngine;



public class SkeletCardPoolContainer : DefaultCardsPoolContainer
{
    protected override GameObject _prefab => CardsDatabase.Instance.SkeletCard;
}
