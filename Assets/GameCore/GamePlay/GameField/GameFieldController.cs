using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.Cards.PlayerCard;
using Assets.GameCore.GamePlay.Currencies;
using Assets.GameCore.GamePlay.GameField;
using Assets.GameCore.GamePlay.MainHeroOptions;
using Assets.GameCore.Utilities;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.GameCore.GamePlay
{
    public class GameFieldController : IParentCardField, IGameFinisher, IGameStarter
    {
        private bool _isCurrentStepDone = false;
        private bool _isGameActive;

        private CardsSpawner _cardsSpawner;
        private IReadOnlyDictionary<Vector2Int, GameCardSlot> _cardSlots;

        private GameFieldManagerHolder _gameFieldManagerHolder;

        public event Action OnGameFinish;

        public GameFieldManagerHolder Managers => _gameFieldManagerHolder;

        [Inject]
        private GameFieldController(CardsSpawner cardsSpawner, GameFieldManagerHolder gameFieldManagers, IInitializableField fieldInitializer)
        {
            _cardsSpawner = cardsSpawner;
            _cardSlots = fieldInitializer.GetField();

            _gameFieldManagerHolder = gameFieldManagers;

            _isCurrentStepDone = true;
        }

        public bool IsGameActive() => _isGameActive;
        public void StartingNewGame()
        {
            _isGameActive = true;
        }

        public async UniTask ExecutePlayerStep(GameCardController target)
        {
            if(!IsGameActive()) return;

            if (!MainHeroHolder.Instance.IsInitialized) return;

            if (!_isCurrentStepDone) return;

            _isCurrentStepDone = false;

            await MainHeroHolder.Instance.ExecuteHeroAction(target);

            await StepFinishing();

            _isCurrentStepDone = true;

            if (MainHeroHolder.Instance.IsHeroDead())
            {
                _isGameActive = false;
                OnGameFinish.Invoke();
            }
        }

        public async UniTask MoveCard(Vector2Int target, Vector2Int origin)
        {
            var slot = _cardSlots[origin];
            var targetSlot = _cardSlots[target];
            slot.Card.SetCoord(target);
            if (targetSlot == null)
            {
                Debug.LogError("Target slot is null");
                return;
            }
            await slot.MoveCard(targetSlot);
        }

        private async UniTask StepFinishing()
        {
            if (TryToGetEmptySlot(out Vector2Int coordToFill))
            {
                List<Vector2Int> neigneighbourSlots = GamePlayeUtil.GetNeigneighbourSlots(coordToFill);

                foreach (var slotCoord in neigneighbourSlots)
                {
                    if (_cardSlots.ContainsKey(slotCoord))
                    {
                        var slot = _cardSlots[slotCoord];
                        if (slot.Card != null && !(slot.Card is PlayerCardController))
                        {
                            //Move 1 card to empty slot
                            await slot.Card.Move(coordToFill);

                            //Then spawn new card on it's place
                            var card = _cardsSpawner.SpawnRandomCard(slot.CachedTransform);
                            slot.SetCard(card);
                            card.Init();
                            card.SetCoord(slotCoord);
                            return;
                        }
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