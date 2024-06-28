using Assets.GameCore.GamePlay.Currencies;
using VContainer;

namespace Assets.GameCore.GameCoreSystems.Managers
{
    public class ManagerRegistrator
    {
        public static void RegistrManager(IContainerBuilder builder)
        {
            builder.Register<CoinsGlobalManager>(Lifetime.Scoped);
            builder.Register<CoinsMatchManager>(Lifetime.Scoped);
        }
    }
}