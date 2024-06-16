using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;

public abstract class BaseEnemyCardController : GameCardController, IFightableCard, IDamageAbleCard
{
    private int _health;
    private string _healthString => _health.ToString();

    protected BaseEnemyCardController(int health, IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
    {
        _health = health;

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
}
