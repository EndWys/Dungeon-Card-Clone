using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.CardObjects.BaseLogic;
using Assets.GameCore.GamePlay.Cards;
using Assets.GameCore.GamePlay.InteractionStratagy;
using System;

public class CoinObject : OnCardObjectBase, IDamageable, ICollectable, IStratageUser<TakeCoinStratage>
{
    private int _coinsValue;

    public override event Action OnNeenToDestroy;
    protected override int ObjectValue => _coinsValue;
    public int Durability => _coinsValue;

    public TakeCoinStratage Strategy => new TakeCoinStratage(this);

    public override void Init(int starterValue)
    {
        //Iniate starter coin value;
    }

    public override void Tap(IPlayerGameCard playerGameCard)
    {
        Strategy.DoAction(playerGameCard);
    }

    public void Collect()
    {
        //When interacting with a coin, the player will move to its cell
        //Goblins can steal a coin
        //Different sources of fire can damage the coin
    }

    public void OnMoveTo()
    {
        //When player move to card with coin -> destroy card and onbject on it and call OnDestroy;
    }

    public void TakeDamage(int damage)
    {
        //Tacking dame reduce value of coin
    }

    public override void DestroyObject()
    {
        OnNeenToDestroy?.Invoke();
        //Add Coins to player Balance
        //Disable Card object
        //Maybe release to it pool
    }
}
