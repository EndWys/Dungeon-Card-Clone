using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.GameField;
using Assets.GameCore.GamePlay.MatchSystem;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelStarter : IStartable
    {

        private MatchController _matchController;
        //private IDisposeableField _fieldDisposer;
        private IParentCardField _cardField;
        private CardsSpawner _cardsSpawner;

        [Inject]
        public LevelStarter(MatchController matchController, IParentCardField cardField, CardsSpawner cardsSpawner)
        {
            _matchController = matchController;
            _cardField = cardField;
            _cardsSpawner = cardsSpawner;
        }

        public void Start()
        {
            _cardsSpawner.Init(_cardField);

            _matchController.StartNewMatch();

            //TODO:Making this inside MatchController in MatchStart()

            //_fieldDisposer.WaitingForDisposeField();
        }
    }
}