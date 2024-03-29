using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public class GameFildView : MonoBehaviour
    {
        public const int FIELD_SIZE = 3;

        //[SerializeField] private PlayerGameCard _playerCard;
        [SerializeField] GameCardSlot[] _slots = new GameCardSlot[FIELD_SIZE * FIELD_SIZE];

        //public PlayerGameCard PlayerCard => _playerCard;

        public IReadOnlyDictionary<Vector2Int, GameCardSlot> BuildFieldMap()
        {
            var fieldMap = new Dictionary<Vector2Int, GameCardSlot>();

            int i = 0;
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    var slot = _slots[i];
                    var coord = new Vector2Int(x, y);
                    fieldMap.Add(coord, slot);

                    i++;
                }
            }
            return fieldMap;
        }
    }
}