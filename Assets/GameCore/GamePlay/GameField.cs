using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.Utilities.Objects;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Assets.GameCore.GamePlay
{
    public interface IParentCardField
    {
        void MoveCard(Vector2Int target, Vector2Int origin);
        void OnCardClick(Vector2Int coord);
    }

    public class GameField : CachedMonoBehaviour, IParentCardField
    {
        private const int FIELD_SIZE = 3;

        [SerializeField] private PlayerGameCard _playerCard;
        [SerializeField] private GameCardSlot[] _slots = new GameCardSlot[FIELD_SIZE * FIELD_SIZE];

        private Dictionary<Vector2Int, GameCardSlot> _cardSlots = new Dictionary<Vector2Int, GameCardSlot>();

        private void Awake()
        {
            InitializeField();
        }

        private void InitializeField()
        {
            int i = 0;
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    GameCardSlot slot = _slots[i];
                    OneGameCard card = slot.GameCard;

                    Vector2Int coord = new Vector2Int(x, y);

                    card.Init(coord, this);
                    _cardSlots.Add(coord, slot);

                    i++;
                }
            }
        }

        public void Step()
        {
            Vector2Int noEmptySlot = new Vector2Int(100,100);
            Vector2Int emptyCoord = noEmptySlot;

            foreach (var slot in _cardSlots)
            {
                if (slot.Value.GameCard == null)
                {
                    emptyCoord = slot.Key;
                } 
                else if (emptyCoord != noEmptySlot && slot.Value.GameCard != _playerCard)
                {
                    slot.Value.GameCard.Move(emptyCoord);
                    return;
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

        public void OnCardClick(Vector2Int coord)
        {
            OneGameCard targetGameCard = _cardSlots[coord].GameCard;
            targetGameCard.OnTap(_playerCard);
            //wait for result
            Step();
        }
    }
}