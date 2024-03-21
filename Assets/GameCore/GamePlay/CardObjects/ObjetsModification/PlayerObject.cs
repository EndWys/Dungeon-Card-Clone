using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.CardObjects.BaseLogic;
using Assets.GameCore.GamePlay.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.CardObjects.ObjetsModification
{
    public class PlayerObject : OnCardObjectBase, IDamageable
    {
        private int _health;

        protected override int ObjectValue => _health;

        public int Durability => _health;

        public override event Action OnNeenToDestroy;

        //Carriying weapon mechanic
        public override void Init(int starterValue)
        {
            //Set starter _health value;
        }
        public override void Tap(IPlayerGameCard playerGameCard)
        {
            //Player click on himself. Just show short tutorial "how to play"
        }

        public void TakeDamage(int damage)
        {
            //Reduce _health by damage
            //If health <= 0 -> Game Over
        }


        public override void DestroyObject()
        {
            //Destroy Player, some actions
        }
    }
}