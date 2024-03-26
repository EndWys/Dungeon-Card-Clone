using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;

namespace Assets.GameCore.GameInitialization
{
    public class GameLoader
    {
        public static bool LoadedOnce { get; private set; }

        [Inject]
        public GameLoader() { }

        public UniTask StartInitialLoading(CancellationToken token)
        {
            //var task = taskDelayed(gameLoadingTasks);

            if (LoadedOnce)
            {
                /*var reloadTask = LoadingTaskV2.create(
                    "ReloadTask",
                    new List<ILoadingTaskV2>()
                    {
                            LoadingTaskV2.finish(OneTimeTasks),
                            task
                    });
                LoadingScene.executeTask(LoadingScene.Style.Loading, reloadTask).Forget();
                return UniTask.CompletedTask;*/
            }

            //LoadingScene.executeTask(LoadingScene.Style.Loading, task).Forget();
            ApplicationLifetimeScope.GetOpenFirstSceneTask().Forget();
            return UniTask.CompletedTask;
        }
    }
}