using Assets.GameCore.GamePlay.Cards;

namespace Assets.GameCore.GamePlay.InteractionStratagy
{
    public abstract class BaseCardStratagy
    {
        public abstract void UseStratagy(IPlayerCardActions playerCard);
    }
}