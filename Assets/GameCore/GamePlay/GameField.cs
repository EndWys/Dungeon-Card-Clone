using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using Assets.GameCore.Utilities;
using Assets.GameCore.Utilities.Objects;
using DG.Tweening;
using System.Collections.Generic;
using System.Drawing;
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
        void OnCardTap(Vector2Int coord);
    }
    public class GameField : IParentCardField, IInitializableField
    {
        private static int FIELD_SIZE => GameFildView.FIELD_SIZE;
        private static Vector2Int PLAYER_SPAWN = new Vector2Int(1, 1);

        private PlayerGameCard _playerCard;
        private IReadOnlyDictionary<Vector2Int, GameCardSlot> _cardSlots;

        private CardsPool _cardsPool;

        [Inject]
        private GameField(GameFildView fildView, CardsPool cardsPool)
        {
            _cardsPool = cardsPool;
            _cardSlots = fildView.BuildFieldMap();
            _playerCard = fildView.PlayerCard;
        }

        public void InitializeField()
        {
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    var coord = new Vector2Int(x, y);

                    GameCardSlot slot = _cardSlots[coord];

                    OneGameCard card;

                    if (coord != PLAYER_SPAWN)
                    {
                        card = _cardsPool.GetRandomCard(slot.CachedTransform);
                    }
                    else
                    {
                        card = _playerCard;
                    }

                    slot.SetCard(card);
                    card.Init(coord, this);
                }
            }
        }

        public void MoveCard(Vector2Int target, Vector2Int origin)
        {
            var movingCard = _cardSlots[origin].GameCard;
            _cardSlots[origin].RemoveCard();
            _cardSlots[target].SetCard(movingCard);
            movingCard.CachedTransform.DOMove(_cardSlots[target].CachedTransform.position, 0.3F);
            movingCard.CachedTransform.SetParent(_cardSlots[target].CachedTransform);
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
                        if (slot.GameCard != null && slot.GameCard != _playerCard)
                        {
                            //Move 1 card to empty slot
                            slot.GameCard.Move(coordToFill);
                            //Then spawn new card on it's place
                            OneGameCard card = _cardsPool.GetRandomCard(slot.CachedTransform);
                            card.Init(slotCoord, this);
                            slot.SetCard(card);
                            return;
                        }
                    }
                }
            }
        }

        private bool TryToGetEmptySlot(out Vector2Int coord)
        {
            var _pairs = _cardSlots.Where(x => x.Value.GameCard == null);

            if (_pairs.Count() == 0)
            {
                coord = Vector2Int.zero;
                return false;
            }

            coord = _pairs.FirstOrDefault().Key;
            return true;
        }

        public void OnCardTap(Vector2Int coord)
        {
            if (_playerCard.ValidateAction(coord))
            {
                OneGameCard targetGameCard = _cardSlots[coord].GameCard;
                targetGameCard.OnTap(_playerCard);
                //wait for result
                Step();
            }
        }
    }
}