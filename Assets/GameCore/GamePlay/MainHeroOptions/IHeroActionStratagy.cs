using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Cysharp.Threading.Tasks;

namespace Assets.GameCore.GamePlay.MainHeroOptions
{
    public interface IHeroActionStratagy
    {
        UniTask UseStratagy(PlayerCardController playerCard, GameCardController targetCard); 
    }
}