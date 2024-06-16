using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.GameField;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelLifeTImeScope : LifetimeScope
    {
        [SerializeField] private GameFildView _gameFieldView;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<NewCardsPool>(Lifetime.Singleton);
            //builder.Register<OldCardsPool>(Lifetime.Singleton);
            builder.Register<CardsSpawner>(Lifetime.Singleton);
            builder.RegisterComponent(_gameFieldView);
            builder.Register<GameFieldInitializer>(Lifetime.Singleton).As<IInitializableField>();
            builder.Register<GameFieldController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterEntryPoint<LevelStarter>();
        }
    }
}