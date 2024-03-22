using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.Utilities.Objects;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
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
            Fill();
        }

        private void Fill()
        {
            Vector2Int coordToFill = _cardSlots.FirstOrDefault(x => x.Value.GameCard == null).Key;

            if (coordToFill == null)
            {
                Debug.Log("No empty slots");
                return;
            }

            List<Vector2Int> neigneighbourSlots = GetNeigneighbourSlots(coordToFill);

            foreach (var slotCoord in neigneighbourSlots)
            {
                if (_cardSlots.TryGetValue(slotCoord, out GameCardSlot slot))
                {
                    if (slot.GameCard != null && slot.GameCard != _playerCard)
                    {
                        slot.GameCard.Move(coordToFill);
                        return;
                    }
                }
            }
        }

        private List<Vector2Int> GetNeigneighbourSlots(Vector2Int coord)
        {
            Vector2Int up = coord + Vector2Int.up;
            Vector2Int down = coord + Vector2Int.down;
            Vector2Int left = coord + Vector2Int.left;
            Vector2Int right = coord + Vector2Int.right;

            return new List<Vector2Int> { up, down, left, right };
        }
    }
}