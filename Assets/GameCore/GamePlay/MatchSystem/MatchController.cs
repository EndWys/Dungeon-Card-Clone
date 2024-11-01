using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.GameCard;
using Assets.GameCore.GamePlay.GameField;
using Cysharp.Threading.Tasks;
using VContainer;

namespace Assets.GameCore.GamePlay.MatchSystem
{
    public class MatchController
    {
        private IGameStarter _gameStarter;

        private IInitializableField _fieldInitializer;
        private IFieldReseter _fieldReseter;

        [Inject]
        private MatchController(IInitializableField gameFieldInitializer, IFieldReseter fieldReseter, IGameFinisher gameFinisher, IGameStarter gameStarter)
        {
            _fieldInitializer = gameFieldInitializer;
            _fieldReseter = fieldReseter;
            _gameStarter = gameStarter;

            gameFinisher.OnGameFinish += FinishMatch;
        }

        public async UniTask StartNewMatch()
        {
            CoinsMatchManager.Instance.ResetCurrency();
            await _fieldInitializer.InitializeField();
            _gameStarter.StartingNewGame();
        }

        public async void FinishMatch()
        {
            await RestartMatch();
        }

        public async UniTask RestartMatch()
        {
            await _fieldReseter.RestField();
            await StartNewMatch();
        }
    }
}