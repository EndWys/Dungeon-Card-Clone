using UnityEngine;

namespace Assets.GameCore.GamePlay.InteractionStratagy
{
    public class TakeCoinStratage : BaseCardStratage<CoinObject>
    {
        public TakeCoinStratage(CoinObject executor) : base(executor) { }
        public override void DoAction(OneGameCard playerCard)
        {
            Debug.Log("TakeCoinStratage");
            //Executor.Collect() // collect item by player
            Executor.DestroyObject(); // destroy item
            //playerCard.Move(targetCard.coordinates)
        }
    }
}