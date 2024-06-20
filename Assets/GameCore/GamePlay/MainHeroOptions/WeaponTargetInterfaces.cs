using Assets.GameCore.GamePlay.MainHeroOptions.Weapons;
using Cysharp.Threading.Tasks;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public interface ISwordTargetCard
    {
        UniTask<bool> SwordHit(IWeapon sword);
    }

    public interface IWandTargetCard
    {
        UniTask<bool> WandHit(Action onKill);
    }
}