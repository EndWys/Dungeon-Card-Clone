using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.GameField;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelStarter : IStartable
    {
        private IInitializableField _fieldInitializer;
        private GameFieldController _fieldController;
        private CardsSpawner _cardsSpawner;

        [Inject]
        public LevelStarter(IInitializableField fieldInitialazer, GameFieldController gameFieldController, CardsSpawner cardsSpawner)
        {
            _fieldInitializer = fieldInitialazer;
            _fieldController = gameFieldController;
            _cardsSpawner = cardsSpawner;
        }

        public void Start()
        {
            _cardsSpawner.Init(_fieldController);
            _fieldInitializer.InitializeField();
        }
    }
}