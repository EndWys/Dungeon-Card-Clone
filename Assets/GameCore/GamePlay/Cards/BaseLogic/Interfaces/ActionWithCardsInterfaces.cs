using System;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces
{
    public interface ICollectableCard
    {
        void Collect();
    }

    public interface IDamageAbleCard
    {
        void TakeDamage(int damage);
    }

    public interface IHealableCard
    {
        void Heal();
    }

    public interface IFightableCard
    {
        void Fight();
    }

    public interface IDefusableCard
    {
        int Power { get; }
        void Defuse(Action<bool> OnFinish);
    }

    public interface IOpenableCard
    {
        void Open();
    }
}