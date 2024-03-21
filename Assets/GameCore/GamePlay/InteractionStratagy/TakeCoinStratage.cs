using Assets.GameCore.GamePlay.Cards;
using UnityEngine;

namespace Assets.GameCore.GamePlay.InteractionStratagy
{
    public class TakeCoinStratage : BaseCardStratage<CoinObject>
    {
        public TakeCoinStratage(CoinObject executor) : base(executor) { }
        public override void DoAction(IPlayerGameCard playerCard)
        {
            Debug.Log("TakeCoinStratage");
            //Executor.Collect() // collect item by player
            playerCard.Move(Executor.ParentCard.position);
            Executor.DestroyObject(); // destroy item
            //playerCard.Move(targetCard.coordinates)
        }
    }
}