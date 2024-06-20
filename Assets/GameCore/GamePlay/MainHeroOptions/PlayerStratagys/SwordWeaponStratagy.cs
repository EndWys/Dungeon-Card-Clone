using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Cysharp.Threading.Tasks;
using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

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
                bool isDead = await swordTarget.SwordHit(playerCard.WieldingWeapon);

                if (isDead)
                    await playerCard.Move(targetCard.Coord);
            }
            else if (targetCard is IDefusableCard defusable)
            {
                /*
                Func<UniTask<bool>> OnFinish = (bool success) =>
                {
                    if (!success)
                    {
                        playerCard.TakeDamage(defusable.Power);
                    }

                    return await playerCard.Move(targetCard.Coord);
                };*/

                await defusable.Defuse(playerCard.Move(targetCard.Coord));
            }
        }
    }
}