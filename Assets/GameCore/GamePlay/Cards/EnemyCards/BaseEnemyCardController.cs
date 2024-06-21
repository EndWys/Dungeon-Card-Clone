using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;
using Assets.GameCore.GamePlay.MainHeroOptions.Weapons;
using Cysharp.Threading.Tasks;
using System;

public abstract class BaseEnemyCardController : GameCardController, IFightableCard, IDamageAbleCard, ISwordTargetCard
{
    private int _health;
    private string _healthString => _health.ToString();

    protected BaseEnemyCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
    {
        _health = cardData.CardValueNumber;

        _gameCardView.OnCardUI.SetCardName(cardData.CardName);
        _gameCardView.OnCardUI.SetCardValue(_healthString);
    }

    public int Power => _health;

    public int Health => _health;

    public void Fight()
    {
        TakeDamage(_health);
    }

    public void TakeDamage(int damage)
    {
        if (_health <= damage)
            _health = 0;
        else
            _health -= damage;

        _gameCardView.OnCardUI.SetCardValue(_healthString);
    }

    public async UniTask<bool> SwordHit(IWeapon sword)
    {
        if (sword == null) 
            return false;

        int power = sword.Power;
        int health = _health;

        sword.UseDurability(health);

        TakeDamage(power);

        return _health == 0;
    }
}
