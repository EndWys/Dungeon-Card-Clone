using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;
using Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCardController : GameCardController, ICollectableCard
{
    private int _power;

    public SwordCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
    {
        _power = cardData.CardValueNumber;

        _gameCardView.OnCardUI.SetCardName(cardData.CardName);
        _gameCardView.OnCardUI.SetCardValue(_power.ToString());

    }

    public void Collect()
    {
        MainHeroHolder.Instance.EquipStratagy(new SwordWeaponStratagy());
    }
}
