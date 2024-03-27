using Assets.GameCore.GamePlay;
using Assets.GameCore.GamePlay.Cards.CardsFactory.CardsPooling;
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
            builder.Register<CardsPool>(Lifetime.Singleton);
            builder.RegisterComponent(_gameFieldView);
            builder.Register<GameField>(Lifetime.Singleton).As<IInitializableField>();
            builder.RegisterEntryPoint<LevelStarter>();
        }
    }
}