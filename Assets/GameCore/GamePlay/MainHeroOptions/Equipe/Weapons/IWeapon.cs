using Assets.GameCore.GamePlay.MainHeroOptions.Equipe;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions.Weapons
{
    public interface IWeapon
    {
        EquipeData EquipeData { get; }
        int Power { get; }
        IHeroActionStratagy Stratagy { get; }
        Action<int> OnDurabilityChange { get; set; }
        void UseDurability(int durability);
    }
}