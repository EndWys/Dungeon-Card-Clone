using Assets.GameCore.GamePlay.Cards.ObjetsModification;
using Assets.GameCore.GamePlay.Cards;
using Assets.GameCore.GamePlay.InteractionStratagy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards.ItemsCards.Potion
{
    public class TakePotionStratagy : BaseCardStratagy
    {
        PotionObject _executor = new PotionObject();
        public TakePotionStratagy(PotionObject executor) => _executor = executor;
        public override void UseStratagy(IPlayerCardActions playerCard)
        {
            Debug.Log("TakePotion");
            playerCard.Move(_executor.ParentCard.Coord);
            playerCard.PlayerObject.Heal(_executor.Durability);
            _executor.Kill(); 
        }
    }
}