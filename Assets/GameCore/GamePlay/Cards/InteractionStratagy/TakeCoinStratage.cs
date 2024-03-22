using Assets.GameCore.GamePlay.Cards.ObjetsModification;
using Assets.GameCore.GamePlay.InteractionStratagy;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.InteractionStratagy
{
    public class TakeCoinStratage : BaseCardStratagy
    {
        CoinObject _executor = new CoinObject();

        public TakeCoinStratage(CoinObject executor) => _executor = executor;
        public override void UseStratagy(IPlayerCardActions playerCard)
        {
            Debug.Log("TakeCoinStratage");
            //Executor.Collect() // collect item by player
            Vector2Int target = _executor.ParentCard.Coord;
            playerCard.Move(target);
            _executor.DestroyObject(); // destroy item
            //playerCard.Move(targetCard.coordinates)
        }
    }
}