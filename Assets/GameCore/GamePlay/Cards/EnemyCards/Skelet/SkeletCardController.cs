using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;

namespace Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet
{
    public class SkeletCardController : BaseEnemyCardController
    {
        public SkeletCardController(CardData cardData, IParentCardField parentCardField, GameCardView gameCardView) : base(cardData, parentCardField, gameCardView)
        {
        }
    }
}