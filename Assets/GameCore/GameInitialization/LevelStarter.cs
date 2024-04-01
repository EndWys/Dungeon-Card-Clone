using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.GameField;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelStarter : IStartable
    {
        private IInitializableField _fieldInitializer;
        private GameFieldController _fieldController;

        [Inject]
        public LevelStarter(IInitializableField fieldInitialazer, GameFieldController gameFieldController)
        {
            _fieldInitializer = fieldInitialazer;
            _fieldController = gameFieldController;
        }

        public void Start()
        {
            _fieldInitializer.InitializeField();
            _fieldController.Init();
        }
    }
}