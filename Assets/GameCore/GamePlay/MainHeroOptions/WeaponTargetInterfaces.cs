using Cysharp.Threading.Tasks;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public interface ISwordTargetCard
    {
        UniTask SwordHit(UniTask onKill);
    }

    public interface IWandTargetCard
    {
        UniTask WandHit(Action onKill);
    }
}