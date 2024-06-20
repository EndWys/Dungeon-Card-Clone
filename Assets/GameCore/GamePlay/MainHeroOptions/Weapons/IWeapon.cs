using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions.Weapons
{
    public interface IWeapon
    {
        int Power { get; }
        IHeroActionStratagy Stratagy { get; }
        Action OnBroke { get; set; }
        Action<int> OnDurabilityChange { get; set; }
        void UseDurability(int durability);

        void Breake();
    }
}