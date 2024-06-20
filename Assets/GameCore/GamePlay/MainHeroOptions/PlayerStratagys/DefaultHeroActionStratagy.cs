using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.Utilities;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys
{
    public class DefaultHeroActionStratagy : IHeroActionStratagy
    {
        public async UniTask UseStratagy(PlayerCardController playerCard, GameCardController targetCard)
        {
            Vector2Int playerCord = playerCard.Coord;
            Vector2Int targetCord = targetCard.Coord;

            bool isValidSlot = GamePlayeUtil.GetNeigneighbourSlots(playerCord).Contains(targetCord);

            if (!isValidSlot) return;

            if (targetCard is ICollectableCard collectable)
            {
                collectable.Collect();
                await playerCard.Move(targetCord);
            }
            else if (targetCard is IOpenableCard openable)
            {
                openable.Open();
            }
            else if (targetCard is IFightableCard fightable)
            {
                playerCard.TakeDamage(fightable.Power);
                fightable.Fight();
                await playerCard.Move(targetCord);
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

                UniTask OnFinish = UniTask.Create(() => playerCard.Move(targetCard.Coord));

                await defusable.Defuse(OnFinish);
            }
        }
    }
}