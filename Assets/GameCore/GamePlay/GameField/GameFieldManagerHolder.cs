using Assets.GameCore.GamePlay.Currencies;
using VContainer;

namespace Assets.GameCore.GamePlay.GameField
{
    public class GameFieldManagerHolder
    {
        public CoinsMatchManager CoinsMatchManager { get; set; }
        public CoinsGlobalManager CoinsGlobalManager { get; set; }

        [Inject]
        public GameFieldManagerHolder(CoinsGlobalManager coinsGlobalManager, CoinsMatchManager coinsMatchManager)
        {
            CoinsMatchManager = coinsMatchManager;
            CoinsGlobalManager = coinsGlobalManager;
        }

    }
}