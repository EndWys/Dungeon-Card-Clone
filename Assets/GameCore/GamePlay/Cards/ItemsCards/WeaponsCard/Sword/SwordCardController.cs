using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.GameField;
using Assets.GameCore.GamePlay.MainHeroOptions;
using Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys;
using Assets.GameCore.GamePlay.MainHeroOptions.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCardController : GameCardController, IWeaponCard
{
    private IWeapon _weapon;

    public int Power => _weapon.Power;
    public IWeapon Weapon => _weapon;

    public SwordCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
    {

        _weapon = new Sword(cardData.CardValueNumber, new SwordWeaponStratagy());

        _gameCardView.OnCardUI.SetCardName(cardData.CardName);
        _gameCardView.OnCardUI.SetCardValue(cardData.CardValueNumber.ToString());

    }

    public void Collect()
    {
        MainHeroHolder.Instance.EquipWeapon(_weapon);
    }
}
