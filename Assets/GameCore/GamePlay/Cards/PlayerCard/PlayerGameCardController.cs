using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;

namespace Assets.GameCore.GamePlay.Cards.PlayerCard
{
    public class PlayerGameCardController : GameCardController, IDamageAbleCard
    {
        public PlayerGameCardController(IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
        {

        }

        public void TakeDamage(int damage)
        {
            //Take damage logic
        }
    }
}