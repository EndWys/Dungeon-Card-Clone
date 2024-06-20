using Assets.GameCore.GamePlay.MainHeroOptions;
using Assets.GameCore.GamePlay.MainHeroOptions.Weapons;
using Cysharp.Threading.Tasks;
using System;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces
{
    public interface ICollectableCard
    {
        void Collect();
    }

    public interface IWeaponCard : ICollectableCard
    {
        IWeapon Weapon { get; } 
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

    public interface IWeaponWielding
    {
        IWeapon WieldingWeapon { get; }

        void Wiel(IWeapon weapon);

        void Unwiel();
    }

    public interface IFightableCard
    {
        int Power { get; }
        void Fight();
    }

    public interface IDefusableCard
    {
        int Power { get; }
        UniTask Defuse(UniTask OnFinish);
    }

    public interface IOpenableCard
    {
        void Open();
    }
}