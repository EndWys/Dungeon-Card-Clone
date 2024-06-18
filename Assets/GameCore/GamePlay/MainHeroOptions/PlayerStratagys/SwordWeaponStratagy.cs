using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Cysharp.Threading.Tasks;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys
{
    public class SwordWeaponStratagy : IHeroActionStratagy
    {
        public async UniTask UseStratagy(PlayerCardController playerCard, GameCardController targetCard)
        {
            if (targetCard is ICollectableCard collectable)
            {
                collectable.Collect();
                await playerCard.Move(targetCard.Coord);
            }
            else if (targetCard is IOpenableCard openable)
            {
                openable.Open();
            }
            else if (targetCard is ISwordTargetCard swordTarget)
            {
                Action onKill = async () => { await playerCard.Move(targetCard.Coord); };
                swordTarget.SwordHit(onKill);
            }
            else if (targetCard is IDefusableCard defusable)
            {
                Action<bool> OnFinish = async delegate (bool success)
                {
                    if (!success)
                    {
                        playerCard.TakeDamage(defusable.Power);
                    }

                    await playerCard.Move(targetCard.Coord);
                };

                defusable.Defuse(OnFinish);
            }
        }
    }
}