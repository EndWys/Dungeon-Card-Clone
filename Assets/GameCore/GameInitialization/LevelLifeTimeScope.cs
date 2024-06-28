using Assets.GameCore.GameCoreSystems.Managers;
using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.BaseLogic.CardsFactory;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
using Assets.GameCore.GamePlay.GameField;
using Assets.GameCore.GamePlay.MatchSystem;
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
            builder.Register<GameFieldManagerHolder>(Lifetime.Singleton);
            builder.Register<CardsSpawner>(Lifetime.Singleton);
            builder.RegisterComponent(_gameFieldView);
            builder.Register<GameFieldInitializer>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameFieldController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<MatchController>(Lifetime.Singleton);
            builder.RegisterEntryPoint<LevelStarter>();
        }
    }
}