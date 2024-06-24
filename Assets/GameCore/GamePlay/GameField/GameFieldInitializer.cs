using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.GameField
{
    public interface IInitializableField
    {
        IReadOnlyDictionary<Vector2Int, GameCardSlot> GetField();
        void InitializeField();
    }

    public interface IFieldReseter
    {
        UniTask RestField();
    }

    public class GameFieldInitializer : IInitializableField, IFieldReseter
    {
        private static Vector2Int PLAYER_SPAWN = new Vector2Int(1, 1);
        private static int FIELD_SIZE => GameFildView.FIELD_SIZE;

        private IReadOnlyDictionary<Vector2Int, GameCardSlot> _cardSlots;

        private CardsSpawner _cardsSpawner;

        [Inject]
        public GameFieldInitializer(CardsSpawner cardsSpawner, GameFildView fieldView)
        {
            _cardsSpawner = cardsSpawner;
            _cardSlots = fieldView.BuildFieldMap();
        }

        public IReadOnlyDictionary<Vector2Int, GameCardSlot> GetField()
        {
            return _cardSlots;
        }

        public void InitializeField()
        {
            for (int y = 0; y < FIELD_SIZE; y++)
            {
                for (int x = 0; x < FIELD_SIZE; x++)
                {
                    var coord = new Vector2Int(x, y);

                    GameCardSlot slot = _cardSlots[coord];

                    GameCardController card;

                    if (coord != PLAYER_SPAWN)
                    {
                        card = _cardsSpawner.SpawnRandomCard(slot.CachedTransform);
                    }
                    else
                    {
                        card = _cardsSpawner.SpawnPlayerCard(slot.CachedTransform);
                    }

                    slot.SetCard(card);
                    card.Init();
                    card.SetCoord(coord);
                }
            }
        }

        public async UniTask RestField()
        {
            foreach (var slot in _cardSlots.Values)
            {
                await slot.RemoveCard();
            }
        }
    }
}