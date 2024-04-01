using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.PlayerCard;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public interface IHeroActionStratagy
    {
        void UseStratagy(PlayerGameCardController playerCard, GameCardController targetCard); 
    }
}