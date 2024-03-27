using VContainer;

namespace Assets.GameCore.GameInitialization
{
    public static class LoadingModuleRegistrations
    {
        public static void register(IContainerBuilder builder)
        {
            //builder.Register<ApiAuth>(Lifetime.Singleton);
            //builder.Register<AnalyticsLoading>(Lifetime.Singleton);
            //builder.Register<ManagerLoading>(Lifetime.Singleton);
            builder.Register<GameLoader>(Lifetime.Singleton);
        }
    }
}