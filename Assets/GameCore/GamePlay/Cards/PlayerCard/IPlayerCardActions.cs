using Assets.GameCore.GamePlay.CardObjects.ObjetsModification;
using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards
{
    public interface IPlayerCardActions
    {
        PlayerObject PlayerObject { get; }

        void Move(Vector2Int pos);
    }
}