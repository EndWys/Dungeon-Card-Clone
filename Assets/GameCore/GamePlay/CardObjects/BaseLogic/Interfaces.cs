using Assets.GameCore.GamePlay.InteractionStratagy;

namespace Assets.GameCore.GamePlay.CardObjects.BaseLogic
{
    public interface ITapable
    {
        void Tap(OneGameCard playerCard);
    }

    public interface IStratageUser<T> where T : class
    {
        T Strategy { get; }
    }

    public interface IDamageable
    {
        int Durability { get; }

        void TakeDamage(int damage);
    }

    public interface ICollectable
    {
        void Collect();
    }
}