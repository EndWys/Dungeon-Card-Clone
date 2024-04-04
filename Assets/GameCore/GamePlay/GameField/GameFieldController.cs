using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.GameField;
using Assets.GameCore.Utilities;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay
{
    public interface IParentCardField
    {
        void MoveCard(Vector2Int target, Vector2Int origin);
    }
    public class GameFieldController : IParentCardField
    {
        private CardsSpawner _cardsSpawner;

        private IReadOnlyDictionary<Vector2Int, GameCardSlot> _cardSlots;

        [Inject]
        private GameFieldController(CardsSpawner cardsSpawner, IInitializableField fieldInitializer)
        {
            _cardsSpawner = cardsSpawner;
            _cardSlots = fieldInitializer.GetField();
        }

        public void MoveCard(Vector2Int target, Vector2Int origin)
        {
            var slot = _cardSlots[origin];
            var targetSlot = _cardSlots[target];
            slot.Card.SetCoord(target);
            slot.MoveCard(targetSlot).Forget();
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