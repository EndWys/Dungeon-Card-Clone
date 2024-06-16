using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet
{
    public class SkeletCardController : BaseEnemyCardController
    {
        public SkeletCardController(int health, IParentCardField parentCardField, GameCardView gameCardView) : base(health, parentCardField, gameCardView)
        {

        }
    }
}