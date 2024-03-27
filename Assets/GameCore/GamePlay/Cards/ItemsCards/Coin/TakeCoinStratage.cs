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
            playerCard.Move(_executor.ParentCard.Coord);
            _executor.Kill();
        }
    }
}