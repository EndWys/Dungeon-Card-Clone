using Assets.GameCore.GamePlay;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelStarter : IStartable
    {
        private IInitializableField _gameField;

        [Inject]
        public LevelStarter(IInitializableField gameField)
        {
            _gameField = gameField;
        }

        public void Start()
        {
            _gameField.InitializeField();
        }
    }
}