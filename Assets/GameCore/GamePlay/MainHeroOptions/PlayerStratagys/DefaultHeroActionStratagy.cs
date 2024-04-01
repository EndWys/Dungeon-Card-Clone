using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using System;

namespace Assets.GameCore.GamePlay.MainHeroOptions.PlayerStratagys
{
    public class DefaultHeroActionStratagy : IHeroActionStratagy
    {
        public void UseStratagy(PlayerGameCardController playerCard, GameCardController targetCard)
        {
            if (targetCard is ICollectableCard collectable)
            {
                collectable.Collect();
                playerCard.Move(targetCard.Coord);
            }
            else if (targetCard is IOpenableCard openable)
            {
                openable.Open();
            }
            else if (targetCard is IFightableCard fightable)
            {
                fightable.Fight();
                playerCard.Move(targetCard.Coord);
            }
            else if (targetCard is IDefusableCard defusable)
            {
                Action<bool> OnFinish = delegate (bool success)
                {
                    if (!success)
                    {
                        playerCard.TakeDamage(defusable.Power);
                    }

                    playerCard.Move(targetCard.Coord);
                };

                defusable.Defuse(OnFinish);
                playerCard.Move(targetCard.Coord);
            }
        }
    }
}