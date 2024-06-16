using Assets.GameCore.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Assets.GameCore.GameInitialization
{
    public class ApplicationLifetimeScope : LifetimeScope
    {
        [SerializeField] SceneData _entryScene;
        [SerializeField] SceneData _firstGameScene;

        private static ApplicationLifetimeScope _instance;

        protected override void Configure(IContainerBuilder builder)
        {
            //Other refistrations
            //...
            LoadingModuleRegistrations.register(builder);
            builder.Register<CardsDatabase>(Lifetime.Singleton);
            //...
            //Other refistrations


            builder.RegisterEntryPoint<GameEntryPoint>();
        }

        protected override void Awake()
        {
            EnsureInstance();
            base.Awake();
        }

        private void EnsureInstance()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static async UniTask GetOpenFirstSceneTask()
        {
            await _instance.OpenFirstScene();
        }

        private async UniTask OpenFirstScene()
        {
            if (_firstGameScene != null)
            {
                await _firstGameScene.LoadAsync(LoadSceneMode.Additive);
                await SceneManager.UnloadSceneAsync(_entryScene.SceneIndex);
            }
        }
    }
}