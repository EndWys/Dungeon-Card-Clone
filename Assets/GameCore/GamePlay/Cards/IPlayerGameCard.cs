using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards
{
    public interface IPlayerGameCard
    {
        void Move(Vector3 pos);
    }
}