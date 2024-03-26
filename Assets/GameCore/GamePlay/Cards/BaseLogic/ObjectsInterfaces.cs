namespace Assets.GameCore.GamePlay.Cards.BaseLogic
{
    public interface ITapable
    {
        void Tap(IPlayerCardActions playerGameCard);
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