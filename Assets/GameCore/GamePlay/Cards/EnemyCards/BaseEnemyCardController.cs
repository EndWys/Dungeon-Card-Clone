using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;

public abstract class BaseEnemyCardController : GameCardController, IFightableCard, IDamageAbleCard
{
    private int _health;

    protected BaseEnemyCardController(int health, IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
    {
        _health = health;
    }

    public int Power => _health;

    public int Health => _health;

    public void Fight()
    {
        _health = 0;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= damage)
        {
            _health = 0;
            return;
        }

        _health -= damage;
    }
}
