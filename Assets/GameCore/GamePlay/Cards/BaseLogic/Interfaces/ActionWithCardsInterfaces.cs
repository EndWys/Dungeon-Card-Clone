using System;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces
{
    public interface ICollectableCard
    {
        void Collect();
    }

    public interface IDamageAbleCard
    {
        int Health { get; }
        void TakeDamage(int damage);
    }

    public interface IHealableCard : IDamageAbleCard
    {
        void Heal(int amount);
    }

    public interface IFightableCard
    {
        int Power { get; }
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