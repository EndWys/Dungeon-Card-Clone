using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Zombie;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory
{
    public class CardsSpawner
    {

        private Dictionary<Type, CardsFactoryBase> _cardsFactoriesMap;
        private IReadOnlyList<CardsFactoryBase> _cardsFactoriesList => _cardsFactoriesMap.Values.ToList();

        private PlayerCardFactory _playerCardFactory;

        [Inject]
        public CardsSpawner() { }

        public void Init(IParentCardField parentCardField)
        {
            _playerCardFactory = new PlayerCardFactory(parentCardField);

            _cardsFactoriesMap = new()
            {
                { typeof(CoinCardController), new CoinsCardFactory(parentCardField) },
                { typeof(SkeletCardController), new SkeletCardFactory(parentCardField) },
                { typeof(ZombieCardController), new ZombieCardFactory(parentCardField) },
            };
        }

        public GameCardController SpawnRandomCard(Transform parent)
        {
            int randomValue = UnityEngine.Random.Range(0, _cardsFactoriesMap.Count);
            var factory = _cardsFactoriesList[randomValue];

            return factory.CreateCard(parent);
        }

        public T SpawnCardByType<T>(Transform parent) where T : GameCardController
        {
            var type = typeof(T);

            if (_cardsFactoriesMap.TryGetValue(type, out CardsFactoryBase factory))
            {
                var card = factory.CreateCard(parent);
                if (card is T tCard)
                    return tCard;
            }

            Debug.LogError("No such card type in the factories list");
            return null;
        }

        public PlayerCardController SpawnPlayerCard(Transform parent)
        {
            var card = _playerCardFactory.CreateCard(parent);

            if (card is PlayerCardController playerCard)
                return playerCard;


            Debug.LogException(new Exception("Player card factory returned not a player card"));
            return null;
        }
    }
}