using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay
{
    public interface IInitializableField
    {
        void InitializeField();
    }

    public interface IParentCardField
    {
        void MoveCard(Vector2Int target, Vector2Int origin);
    }
    public class GameField : IParentCardField, IInitializableField
    {
        private static Vector2Int PLAYER_SPAWN = new Vector2Int(1, 1);
        private static int FIELD_SIZE => GameFildView.FIELD_SIZE;

        private CardsPool _cardsPool;

        private IReadOnlyDictionary<Vector2Int, GameCardSlot> _cardSlots;

        [Inject]
        private GameField(GameFildView fildView, CardsPool cardsPool)
        {
            _cardsPool = cardsPool;
            _cardSlots = fildView.BuildFieldMap();
        }

        public void InitializeField()
        {
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    var coord = new Vector2Int(x, y);

                    GameCardSlot slot = _cardSlots[coord];

                    GameCardController card = null;

                     if (coord != PLAYER_SPAWN)
                     {
                        //Factory must create card
                        //then pool must to choose prefab for this card
                     }
                     else
                     {
                        //
                     } 

                     slot.SetCard(card);
                     card.Init();
                }
            }
        }

        public void MoveCard(Vector2Int target, Vector2Int origin)
        {
            _cardSlots[origin].MoveCard(_cardSlots[target]);
        }

        private void Step()
        {
            if (TryToGetEmptySlot(out Vector2Int coordToFill))
            {
                List<Vector2Int> neigneighbourSlots = GamePlayeUtil.GetNeigneighbourSlots(coordToFill);

                foreach (var slotCoord in neigneighbourSlots)
                {
                    if (_cardSlots.ContainsKey(slotCoord))
                    {
                        var slot = _cardSlots[slotCoord];
                       /* if (slot.GameCard != null && slot.GameCard != _playerCard)
                        {
                            //Move 1 card to empty slot
                            slot.GameCard.Move(coordToFill);
                            //Then spawn new card on it's place
                            GameCardBase card = _cardsPool.GetRandomCard(slot.CachedTransform);
                            card.Init(slotCoord, this);
                            slot.SetCard(card);
                            return;
                        } */
                    }
                }
            }
        }

        private bool TryToGetEmptySlot(out Vector2Int coord)
        {
            var _pairs = _cardSlots.Where(x => x.Value.Card == null);

            if (_pairs.Count() == 0)
            {
                coord = Vector2Int.zero;
                return false;
            }

            coord = _pairs.FirstOrDefault().Key;
            return true;
        }
    }
}