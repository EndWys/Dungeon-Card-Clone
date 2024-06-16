using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Skelet;
using Assets.GameCore.GamePlay.Cards.EnemyCards.Zombie;
using Assets.GameCore.GamePlay.Cards.ItemsCards.Coin;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling
{
    public class NewCardsPool
    {
        private CardsDatabase _database => CardsDatabase.Instance;


        private DefaultCardsPoolContainer _playerCardPoolContainer = new DefaultCardsPoolContainer();
        public ICardsPoolContainer PlayerCardPoolContainer => _playerCardPoolContainer;

        public DefaultCardsPoolContainer _coinCardPoolContainer = new DefaultCardsPoolContainer();
        public ICardsPoolContainer CoinCardPoolContainer => _coinCardPoolContainer;

        public DefaultCardsPoolContainer _skeletCardPoolContainer = new DefaultCardsPoolContainer();
        public ICardsPoolContainer SkeletCardPoolContainer => _skeletCardPoolContainer;

        public DefaultCardsPoolContainer _zombieCardPoolContainer = new DefaultCardsPoolContainer();
        public ICardsPoolContainer ZombieCardPoolContainer => _zombieCardPoolContainer;

        [Inject]
        public NewCardsPool()
        {
            _playerCardPoolContainer.Initialize(_database.PlayerCard);
            _coinCardPoolContainer.Initialize(_database.CoinCard);
            _zombieCardPoolContainer.Initialize(_database.ZombieCard);
            _skeletCardPoolContainer.Initialize(_database.SkeletCard);
        }
    }
}