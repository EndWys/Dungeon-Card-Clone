using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public interface ISwordTargetCard
    {
        void SwordHit(Action onKill);
    }

    public interface IWandTargetCard
    {
        void WandHit(Action onKill);
    }
}