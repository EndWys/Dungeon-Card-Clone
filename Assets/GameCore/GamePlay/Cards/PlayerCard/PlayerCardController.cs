using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.BaseLogic.Interfaces;
using Assets.GameCore.GamePlay.MainHeroOptions;

namespace Assets.GameCore.GamePlay.Cards.PlayerCard
{
    public class PlayerCardController : GameCardController, IDamageAbleCard
    {
        public PlayerCardController(IParentCardField parentCardField, GameCardView gameCardView) : base(parentCardField, gameCardView)
        {
            MainHeroHolder.Instance.Init(this);
        }

        public void TakeDamage(int damage)
        {
            //Take damage logic
        }
    }
}