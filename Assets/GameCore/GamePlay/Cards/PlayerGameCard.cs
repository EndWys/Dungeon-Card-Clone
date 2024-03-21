using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards
{
    public class PlayerGameCard : OneGameCard, IPlayerGameCard
    {
        public void Move(Vector3 pos)
        {
            transform.DOMove(pos,0.3F);
        }
    }
}