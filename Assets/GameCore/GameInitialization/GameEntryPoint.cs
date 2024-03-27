using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class GameEntryPoint : IAsyncStartable
    {
        readonly GameLoader _gameLoader;

        [Inject]
        public GameEntryPoint(GameLoader gameLoader)
        {
            _gameLoader = gameLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _gameLoader.StartInitialLoading(cancellation);
        }
    }
}