using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.Utilities
{
    public static class GamePlayeUtil
    {
        public static List<Vector2Int> GetNeigneighbourSlots(Vector2Int coord)
        {
            Vector2Int up = coord + Vector2Int.up;
            Vector2Int down = coord + Vector2Int.down;
            Vector2Int left = coord + Vector2Int.left;
            Vector2Int right = coord + Vector2Int.right;

            return new List<Vector2Int> { up, down, left, right };
        }
    }
}