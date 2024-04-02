using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory
{
    public class CardsSpawner
    {
        private CardsPool _cardsPool;
        private IParentCardField _parentCardField;

        List<CardsFactoryBase> _cardsFactories = new();

        [Inject]
        public CardsSpawner(CardsPool cardsPool)
        {
            _cardsPool = cardsPool;
        }

        public void Init(IParentCardField parentCardField)
        {
            _parentCardField = parentCardField;

            _cardsFactories = FabricList().ToList();
        }

        private IEnumerable<CardsFactoryBase> FabricList()
        {
            yield return new CoinsCardFactory(_cardsPool, _parentCardField);
        }

        public GameCardController SpawnRandomCard(Transform parent)
        {
            var factory = _cardsFactories[Random.Range(0, _cardsFactories.Count)];

            return factory.CreateCard(parent);
        }
    }
}