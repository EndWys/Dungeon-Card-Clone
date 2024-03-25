using Assets.GameCore.GamePlay.Cards.BaseLogic;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.CardsModification;
using Assets.GameCore.PoolingSystem;
using Assets.GameCore.Utilities.Objects;
using DG.Tweening;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

namespace Assets.GameCore.GamePlay
{
    public interface IParentCardField
    {
        void MoveCard(Vector2Int target, Vector2Int origin);
        void OnCardClick(Vector2Int coord);
    }

    public class GameField : CachedMonoBehaviour, IParentCardField
    {
        private static Vector2Int PLAYER_SPAWN = new Vector2Int(1, 1);
        private const int FIELD_SIZE = 3;

        [SerializeField] CardsDatabase _cardsDatabase;

        [SerializeField] private PlayerGameCard _playerCard;
        private GameCardSlot[] _slots = new GameCardSlot[FIELD_SIZE * FIELD_SIZE];
        private Dictionary<Vector2Int, GameCardSlot> _cardSlots = new Dictionary<Vector2Int, GameCardSlot>();

        private CardsPool _cardsPool;

        private void Awake()
        {
            _cardsDatabase.Init();

            FindAllSlots();
            InitializePool();
            InitializeField();
        }
        private void FindAllSlots()
        {
            _slots = GetComponentsInChildren<GameCardSlot>();
        }

        private void InitializePool()
        {
            _cardsPool = new CardsPool();
            _cardsPool.Initialize();
        }

        private void InitializeField()
        {
            int i = 0;
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    Vector2Int coord = new Vector2Int(x, y);

                    OneGameCard card;
                    GameCardSlot slot = _slots[i];

                    if (coord != PLAYER_SPAWN)
                    {
                        card = _cardsPool.GetRandomCard(slot.CachedTransform);
                    }
                    else
                    {
                        card = _playerCard;
                    }

                    card.Init(coord, this);
                    slot.SetCard(card);
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
                        //Spawn new card
                        OneGameCard card = _cardsPool.GetRandomCard(slot.CachedTransform);
                        card.Init(slotCoord, this);
                        slot.SetCard(card);
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