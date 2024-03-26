using Assets.GameCore.GamePlay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class LevelLifeTImeScope : LifetimeScope
    {
        [SerializeField] private GameField _gameField;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_gameField);
        }
    }
}