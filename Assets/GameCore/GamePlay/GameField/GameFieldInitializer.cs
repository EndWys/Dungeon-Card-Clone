using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using System.Collections;
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

    public class GameFieldInitializer : IInitializableField
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

                    GameCardController card = _cardsSpawner.SpawnRandomCard(slot.CachedTransform);

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
    }
}