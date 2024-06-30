using Assets.GameCore.GameCoreSystems.Currencies;
using VContainer;

namespace Assets.GameCore.GamePlay.Currencies
{
    public class CoinsGlobalManager : BaseCurrencyManager<CoinsGlobalManager>
    {
        protected override string CurrencyName => "Global";

        
    }
}