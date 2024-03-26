using UnityEngine;

namespace Assets.GameCore.GamePlay.Cards
{
    public interface IPlayerCardActions
    {
        void Move(Vector2Int pos);
    }
}